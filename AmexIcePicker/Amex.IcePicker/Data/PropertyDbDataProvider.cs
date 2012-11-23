using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Amex.IcePicker.Properties;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;
using System.Data;

namespace Amex.IcePicker.Data
{
    public class PropertyDbDataProvider : IPropertyDataProvider
    {
        public Property SetProperty(Property property)
        {
            return _setProperty(property);
        }

        public Property GetProperty(string name)
        {
            return _getProperty(name);
        }

        private Property _getProperty(string name)
        {
            Property property = new Property();

            Database db = DatabaseFactory.CreateDatabase();
            using (DbCommand cmd = db.GetStoredProcCommand("Property_GetById"))
            {
                db.AddInParameter(cmd, "@_name", DbType.String, name);
                using (DbDataReader reader = (DbDataReader)db.ExecuteReader(cmd))
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            property = _extractProperty(reader);
                            break;
                        }
                    }
                }
            }
            return property;
        }

        private Property _setProperty(Property property)
        {
            if (String.IsNullOrEmpty(property.Name))
                property.Name = Guid.NewGuid().ToString();
            
            Database db = DatabaseFactory.CreateDatabase();

            using (DbCommand cmd = db.GetStoredProcCommand("Property_Set"))
            {
                db.AddInParameter(cmd, "@_name", DbType.String, property.Name);
                db.AddInParameter(cmd, "@_value", DbType.String, property.Value);
                db.AddInParameter(cmd, "@_clientid", DbType.String, property.ClientId);
                db.AddInParameter(cmd, "@_locale", DbType.String, property.Locale);
                db.ExecuteNonQuery(cmd);
            }

            return property;
        }

        private Property _extractProperty(DbDataReader reader)
        {
            Property property = new Property();
            property.ClientId = reader["ClientId"].ToString();
            property.Locale = reader["Locale"].ToString();
            property.DateCreated = Convert.ToDateTime(reader["DateCreated"]);
            property.Name = reader["Name"].ToString();
            property.Value = reader["Value"].ToString();
            property.DateModified = Convert.ToDateTime(reader["DateModified"]);
            return property;
        }
    }
}
