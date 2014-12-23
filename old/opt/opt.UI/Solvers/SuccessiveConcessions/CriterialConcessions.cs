using System;
using System.Collections;
using System.Collections.Generic;
using opt.DataModel;

namespace opt.Solvers.SuccessiveConcessions
{
    public class CriterialConcessions : IEnumerable
    {
        // Словарь для хранения уступок
        private Dictionary<TId, CriterialConcession> _concessions;

        public CriterialConcessions()
        {
            _concessions = new Dictionary<TId, CriterialConcession>();
        }

        public CriterialConcession this[TId index]
        {
            get
            {
                if (_concessions.ContainsKey(index))
                {
                    return _concessions[index];
                }
                else
                {
                    throw new ArgumentException("There is no concession with such ID in the collection");
                }
            }
        }

        #region IEnumerable Members

        public IEnumerator GetEnumerator()
        {
            return _concessions.Values.GetEnumerator();
        }

        #endregion

        public void Add(CriterialConcession newConcession)
        {
            if (newConcession != null)
            {
                if (!_concessions.ContainsKey(newConcession.CriterionId))
                {
                    _concessions.Add(newConcession.CriterionId, (CriterialConcession)newConcession.Clone());
                }
                else
                {
                    throw new ArgumentException("Concession with such ID already exists in the collection");
                }
            }
            else
            {
                throw new ArgumentNullException("Constraint to add must not be null");
            }
        }

        public void Remove(TId concessionId)
        {
            if (_concessions.ContainsKey(concessionId))
            {
                _concessions.Remove(concessionId);
            }
            else
            {
                throw new ArgumentException("There is no concession with such ID in the collection");
            }
        }

        public void ClearAll()
        {
            foreach (CriterialConcession cc in _concessions.Values)
            {
                cc.Clear();
            }
        }

        public bool IsFirstElementIndex(TId index)
        {
            if (_concessions.ContainsKey(index))
            {
                int indexPosition = 0;
                foreach(CriterialConcession concession in _concessions.Values)
                {
                    indexPosition++;
                    if (concession.CriterionId == index)
                    {
                        break;
                    }
                }
                return (indexPosition == 1) ? true : false;
            }
            else
            {
                throw new ArgumentException("There is no element with such index in the collection");
            }
        }
    }
}
