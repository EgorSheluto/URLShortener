using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkShorteningService
{
    class DBMySQLQuerys
    {
        //Select
        public const string SELECT_URLINFO = @"SELECT id, fullurl, shorturl, createdate, amount FROM URLInfo";
        public const string SELECT_FULLURL_IF_EXIST = @"SELECT COUNT(id) FROM URLInfo WHERE fullurl = '{0}'";
        public const string SELECT_SHORTURL_IF_EXIST = @"SELECT COUNT(id) FROM URLInfo WHERE shorturl = '{0}'";
        public const string SELECT_URLINFO_MAX_ID = @"SELECT MAX(id) FROM URLInfo";
        //Insert
        public const string INSERT_URLINFO = @"INSERT INTO URLInfo (fullurl, shorturl, createdate, amount) VALUES ('{0}', '{1}', '{2}', {3})";
        //Delete
        public const string DELETE_URLINFO_ROW = @"DELETE FROM URLInfo WHERE id = {0}";
        //Update
        public const string UPDATE_URLINFO_AMOUNT = @"UPDATE URLInfo SET amount = amount + 1 WHERE id = {0}";
        public const string UPDATE_URLINFO_FULLURL = @"UPDATE URLInfo SET fullurl = '{0}' WHERE id = {1}";
        public const string UPDATE_URLINFO_SHORTURL = @"UPDATE URLInfo SET shorturl = '{0}' WHERE id = {1}";
        public const string UPDATE_URLINFO_AMOUNT_CLEAR = @"UPDATE URLInfo SET amount = 0 WHERE id = {0}";
    }
}
