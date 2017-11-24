using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace customerAPI.DataAccess
{
    /// <summary>
    /// Data Factory
    /// </summary>
    public static class DataFactory
    {
        private const int PeopleCount = 100;

        private static IQueryable<Models.Person> _people = null;

        /// <summary>
        /// People
        /// </summary>
        public static IQueryable<Models.Person> People
        {
            get
            {
                if(_people ==null)
                {
                    var list = new List<Models.Person>();
                    for(int i=0;i<PeopleCount;i++)
                    {
                        var p = ModelMaker.PersonMake();
                        list.Add(p);
                    }
                    _people = list.AsQueryable<Models.Person>();
                }
                return _people;
            }
        }

    }
}
