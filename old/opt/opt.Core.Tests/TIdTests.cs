using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using opt.Comparers;
using opt.ConstraintValidation;
using opt.DataModel.New;

namespace opt.Core.Tests
{
    [TestClass]
    public class TIdTests
    {

        [TestMethod]
        public void T2()
        {
            ConstraintDictionary consDict = new ConstraintDictionary();
            ObjectiveConstraint objCons1 = new ObjectiveConstraint(1, 1, Relation.Equal, 0.0);
            consDict.Add(objCons1);
        }


        //[TestMethod]
        //public void T1()
        //{
        //    AggregateComparer aggComp = new AggregateComparer();
        //    RealRelationComparer realComp = new RealRelationComparer();
        //    aggComp.AddComparer(realComp);

        //    AggregateConstraintValidator aggVal = new AggregateConstraintValidator();
        //    ConstraintValidator consVal = new ConstraintValidator(aggComp);
        //    ObjectiveConstraintValidator objConsVal = new ObjectiveConstraintValidator(aggComp);
        //    aggVal.AddValidator<Constraint>(consVal);
        //    aggVal.AddValidator<ObjectiveConstraint>(objConsVal);

        //    ValueDictionaryValidator expVal = new ValueDictionaryValidator(aggVal);
        //    Experiment exp = new Experiment(0, 1);
        //    ObjectiveConstraint objCons = new ObjectiveConstraint(0, 0, Relation.Equal, 10.0);

        //    exp.FunctionalConstraintValues.Add(0, 10.0);

        //    expVal.ValidateConstraint(exp.FunctionalConstraintValues, objCons);
        //}





        [TestMethod]
        public void Serialization()
        {
            TId id = new TId(10);

            BinaryFormatter formatter = new BinaryFormatter();
            using (MemoryStream stream = new MemoryStream())
            {
                formatter.Serialize(stream, id);

                byte[] serializedBytes = stream.ToArray();
            }
        }

        [TestMethod]
        public void Deserialization()
        {
            TId id = new TId(10);

            BinaryFormatter formatter = new BinaryFormatter();
            using (MemoryStream stream = new MemoryStream())
            {
                formatter.Serialize(stream, id);
                byte[] serializedBytes = stream.ToArray();

                stream.Seek(0, SeekOrigin.Begin);
                TId id1 = (TId)formatter.Deserialize(stream);

                Assert.AreEqual(id, id1);
            }
        }
    }
}