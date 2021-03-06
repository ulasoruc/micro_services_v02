using System;
using System.Collections.Generic;
using System.Text;
using DC = Dapper.Contrib.Extensions;

namespace micro_services_dal.Models.zoradamlar_com_db_mic_user
{
    [DC.Table("role")]
    public class role
    {
        [DC.Key]
        public long role_id { get; set; }
        public string role_name { get; set; }
        public int role_intvalue { get; set; }
        public string role_strvalue { get; set; }
        public bool deletedrole_id { get; set; }
        public bool role_active { get; set; }
        public bool role_use { get; set; }
    }

}
