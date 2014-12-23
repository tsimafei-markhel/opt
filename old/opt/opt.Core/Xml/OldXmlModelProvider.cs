using System;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Linq;
using System.Xml.XPath;
using opt.DataModel;

namespace opt.Xml
{
    [Obsolete("For backward compatibility only. In other cases please use NewXmlModelProvider")]
    internal static class OldXmlModelProvider
    {
        private static class XPaths
        {
            public const string Constraint = "/ModelInfo/FunctionalConstraints/Constraint";
            public const string Criterion = "/ModelInfo/Criteria/Criterion";
            public const string Experiment = "/ModelInfo/Experiments/Experiment";
            public const string Parameter = "/ModelInfo/Parameters/Parameter";
        }

        private static class Elements
        {
            public const string Constraint = "Constraint";
            public const string ConstraintValue = "ConstraintValue";
            public const string Criteria = "Criteria";
            public const string Criterion = "Criterion";
            public const string CriterionValue = "CriterionValue";
            public const string Experiment = "Experiment";
            public const string Experiments = "Experiments";
            public const string FunctionalConstraints = "FunctionalConstraints";
            public const string ModelInfo = "ModelInfo";
            public const string Parameter = "Parameter";
            public const string Parameters = "Parameters";
            public const string ParameterValue = "ParameterValue";
        }

        private static class Attributes
        {
            public const string ConstraintId = "ConstraintId";
            public const string CriterionId = "CriterionId";
            public const string Expression = "Expression";
            public const string Id = "Id";
            public const string Name = "Name";
            public const string Number = "Number";
            public const string MaxValue = "MaxValue";
            public const string MinValue = "MinValue";
            public const string ParameterId = "ParameterId";
            public const string Sign = "Sign";
            public const string Type = "Type";
            public const string Value = "Value";
            public const string VariableIdentifier = "VariableIdentifier";
            public const string Weight = "Weight";
        }

        public static Model Open(string filePath)
        {
            Model model = new Model();

            // Загрузим файл модели
            using (XmlReader modelDocReader = XmlReader.Create(filePath))
            {
                XPathDocument modelDoc = new XPathDocument(modelDocReader);
                XPathNavigator modelNavigator = modelDoc.CreateNavigator();

                // Загрузим оптимизируемые параметры
                XPathNodeIterator paramsIterator = modelNavigator.Select(XPaths.Parameter);
                while (paramsIterator.MoveNext())
                {
                    var parameter = ParseParameter(paramsIterator.Current);
                    model.Parameters.Add(parameter.Id, parameter);
                }

                // Загрузим критерии оптимальности
                XPathNodeIterator criteriaIterator = modelNavigator.Select(XPaths.Criterion);
                while (criteriaIterator.MoveNext())
                {
                    var criterion = ParseCriterion(criteriaIterator.Current);
                    model.Criteria.Add(criterion.Id, criterion);
                }

                // Загрузим функциональные ограничения
                XPathNodeIterator constraintsIterator = modelNavigator.Select(XPaths.Constraint);
                while (constraintsIterator.MoveNext())
                {
                    var constraint = ParseConstraint(constraintsIterator.Current);
                    model.FunctionalConstraints.Add(constraint.Id, constraint);
                }

                // Наконец, загрузим эксперименты
                XPathNodeIterator experimentsIterator = modelNavigator.Select(XPaths.Experiment);
                while (experimentsIterator.MoveNext())
                {
                    Experiment experiment = ParseExperiment(experimentsIterator.Current);
                    model.Experiments.Add(experiment.Id, experiment);
                }
            }

            return model;
        }

        internal static XDocument GetXDocument(Model model)
        {
            // Создадим новый документ
            var modelDoc = new XDocument(new XDeclaration("1.0", "utf-8", string.Empty),
                                               new XElement(Elements.ModelInfo));

            // Создадим ноды документа
            var paramsNode = new XElement(Elements.Parameters);
            var criteriaNode = new XElement(Elements.Criteria);
            var constrNode = new XElement(Elements.FunctionalConstraints);
            var expNode = new XElement(Elements.Experiments);

            // Запишем оптимизируемые параметры в соответствующую ноду
            foreach (Parameter param in model.Parameters.Values)
            {
                paramsNode.Add(new XElement(Elements.Parameter,
                                    new XAttribute(Attributes.Id, param.Id.ToString()),
                                    new XAttribute(Attributes.Name, param.Name),
                                    new XAttribute(Attributes.VariableIdentifier, param.VariableIdentifier),
                                    new XAttribute(Attributes.MinValue, param.MinValue.ToString()),
                                    new XAttribute(Attributes.MaxValue, param.MaxValue.ToString())
                                    )
                              );
            }

            // Запишем критерии оптимальности в соответствующую ноду
            foreach (Criterion crit in model.Criteria.Values)
            {
                criteriaNode.Add(new XElement(Elements.Criterion,
                                    new XAttribute(Attributes.Id, crit.Id.ToString()),
                                    new XAttribute(Attributes.Name, crit.Name),
                                    new XAttribute(Attributes.VariableIdentifier, crit.VariableIdentifier),
                                    new XAttribute(Attributes.Type, crit.Type.ToString()),
                                    new XAttribute(Attributes.Weight, crit.Weight.ToString()),
                                    new XAttribute(Attributes.Expression, crit.Expression)
                                    )
                                );
            }

            // Запишем функциональные ограничения в соответствующую ноду
            foreach (Constraint constr in model.FunctionalConstraints.Values)
            {
                constrNode.Add(new XElement(Elements.Constraint,
                                    new XAttribute(Attributes.Id, constr.Id.ToString()),
                                    new XAttribute(Attributes.Name, constr.Name),
                                    new XAttribute(Attributes.VariableIdentifier, constr.VariableIdentifier),
                                    new XAttribute(Attributes.Sign, constr.ConstraintRelation.ToString()),
                                    new XAttribute(Attributes.Value, constr.Value.ToString()),
                                    new XAttribute(Attributes.Expression, constr.Expression)
                                    )
                               );
            }

            // Запишем эксперименты в соответствующую ноду
            foreach (Experiment exp in model.Experiments.Values)
            {
                // Создадим ноду эксперимента с нужными атрибутами
                var expElement = new XElement(Elements.Experiment,
                                        new XAttribute(Attributes.Id, exp.Id.ToString()),
                                        new XAttribute(Attributes.Number, exp.Number.ToString()));

                // Сохраним значения оптимизируемых параметров для данного эксперимента
                foreach (KeyValuePair<TId, double> paramValue in exp.ParameterValues)
                {
                    expElement.Add(new XElement(Elements.ParameterValue,
                                        new XAttribute(Attributes.ParameterId, paramValue.Key.ToString()),
                                        new XAttribute(Attributes.Value, paramValue.Value.ToString())
                                        )
                                  );
                }

                // Сохраним значения критериев оптимальности для данного эксперимента
                foreach (KeyValuePair<TId, double> critValue in exp.CriterionValues)
                {
                    expElement.Add(new XElement(Elements.CriterionValue,
                                        new XAttribute(Attributes.CriterionId, critValue.Key.ToString()),
                                        new XAttribute(Attributes.Value, critValue.Value.ToString())
                                        )
                                  );
                }

                // Сохраним значения функциональных ограничений для данного эксперимента
                foreach (KeyValuePair<TId, double> constrValue in exp.ConstraintValues)
                {
                    expElement.Add(new XElement(Elements.ConstraintValue,
                                        new XAttribute(Attributes.ConstraintId, constrValue.Key.ToString()),
                                        new XAttribute(Attributes.Value, constrValue.Value.ToString())
                                        )
                                  );
                }

                // Добавим ноду данного эксперимента в соответствующую ноду
                expNode.Add(expElement);
            }

            // Добавим ноды в корневой элемент
            modelDoc.Root.Add(paramsNode);
            modelDoc.Root.Add(criteriaNode);
            modelDoc.Root.Add(constrNode);
            modelDoc.Root.Add(expNode);

            return modelDoc;
        }

        public static void Save(Model model, string filePath)
        {
            XDocument modelDoc = GetXDocument(model);
            modelDoc.Save(filePath);
        }

        private static Parameter ParseParameter(XPathNavigator nodeNavigator)
        {
            TId id = TId.Parse(nodeNavigator.GetAttribute(Attributes.Id, string.Empty));
            string name = nodeNavigator.GetAttribute(Attributes.Name, string.Empty);
            string variableIdentifier = nodeNavigator.GetAttribute(Attributes.VariableIdentifier, string.Empty);
            double minValue = Convert.ToDouble(nodeNavigator.GetAttribute(Attributes.MinValue, string.Empty));
            double maxValue = Convert.ToDouble(nodeNavigator.GetAttribute(Attributes.MaxValue, string.Empty));

            return new Parameter(id, name, variableIdentifier, minValue, maxValue);
        }

        private static Criterion ParseCriterion(XPathNavigator nodeNavigator)
        {
            TId id = TId.Parse(nodeNavigator.GetAttribute(Attributes.Id, string.Empty));
            string name = nodeNavigator.GetAttribute(Attributes.Name, string.Empty);
            string variableIdentifier = nodeNavigator.GetAttribute(Attributes.VariableIdentifier, string.Empty);
            CriterionType criterionType = (CriterionType)Enum.Parse(typeof(CriterionType), nodeNavigator.GetAttribute(Attributes.Type, string.Empty));
            int weight = Convert.ToInt32(nodeNavigator.GetAttribute(Attributes.Weight, string.Empty));
            string expression = nodeNavigator.GetAttribute(Attributes.Expression, string.Empty);

            return new Criterion(id, name, variableIdentifier, criterionType, expression) { Weight = weight };
        }

        private static Constraint ParseConstraint(XPathNavigator nodeNavigator)
        {
            TId id = TId.Parse(nodeNavigator.GetAttribute(Attributes.Id, string.Empty));
            string name = nodeNavigator.GetAttribute(Attributes.Name, string.Empty);
            string variableIdentifier = nodeNavigator.GetAttribute(Attributes.VariableIdentifier, string.Empty);
            Relation constraintRelation = (Relation)Enum.Parse(typeof(Relation), nodeNavigator.GetAttribute(Attributes.Sign, string.Empty));
            double value = Convert.ToDouble(nodeNavigator.GetAttribute(Attributes.Value, string.Empty));
            string expression = nodeNavigator.GetAttribute(Attributes.Expression, string.Empty);

            return new Constraint(id, name, variableIdentifier, constraintRelation, value, expression);
        }

        private static Experiment ParseExperiment(XPathNavigator nodeNavigator)
        {
            TId id = TId.Parse(nodeNavigator.GetAttribute(Attributes.Id, string.Empty));
            int number = Convert.ToInt32(nodeNavigator.GetAttribute(Attributes.Number, string.Empty));

            Experiment experiment = new Experiment(id, number);

            // Выдерем значения оптимизируемых параметров
            XPathNodeIterator paramValueIterator = nodeNavigator.SelectChildren(Elements.ParameterValue, string.Empty);
            while (paramValueIterator.MoveNext())
            {
                experiment.ParameterValues.Add(
                    Convert.ToInt32(paramValueIterator.Current.GetAttribute(Attributes.ParameterId, string.Empty)),
                    Convert.ToDouble(paramValueIterator.Current.GetAttribute(Attributes.Value, string.Empty)));
            }

            // Выдерем значения критериев оптимальности
            XPathNodeIterator critValueIterator = nodeNavigator.SelectChildren(Elements.CriterionValue, string.Empty);
            while (critValueIterator.MoveNext())
            {
                experiment.CriterionValues.Add(
                    Convert.ToInt32(critValueIterator.Current.GetAttribute(Attributes.CriterionId, string.Empty)),
                    Convert.ToDouble(critValueIterator.Current.GetAttribute(Attributes.Value, string.Empty)));
            }

            // Выдерем значения функциональных ограничений
            XPathNodeIterator constrValueIterator = nodeNavigator.SelectChildren(Elements.ConstraintValue, string.Empty);
            while (constrValueIterator.MoveNext())
            {
                experiment.ConstraintValues.Add(
                    Convert.ToInt32(constrValueIterator.Current.GetAttribute(Attributes.ConstraintId, string.Empty)),
                    Convert.ToDouble(constrValueIterator.Current.GetAttribute(Attributes.Value, string.Empty)));
            }

            return experiment;
        }
    }
}