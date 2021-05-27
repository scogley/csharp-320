using System;
using System.Collections.Generic;
using System.Text;
using DriverDB;

namespace DriverRepository
{
    public class DatabaseManager
    {
        private static readonly Formula1Context entities;

        // Initialize and open the database connection
        static DatabaseManager()
        {
            entities = new Formula1Context();
        }

        // Provide an accessor to the database
        public static Formula1Context Instance
        {
            get
            {
                return entities;
            }
        }
    }
}
