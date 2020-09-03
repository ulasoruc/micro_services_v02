using System.Collections.Generic;
using System.Linq;
using micro_services_dal;
using micro_services_share;
using micro_services_dal.Models.zoradamlar_com_db_mic_user;

namespace micro_services_bus.zoradamlar_com_db_mic_user
{
    public partial class Op_dbserver
    {
        public dbserver Savedbserver(dbserver DBSERVER, string DBTYPE, string CONNSTR, bool SYNC = false, bool TRAN = false)
        {
            dbserver result = new dbserver();
            BeforeSavedbserver(DBSERVER: DBSERVER,DBTYPE: DBTYPE, CONNSTR:CONNSTR, SYNC:SYNC, TRAN: TRAN);
            //eğer birden fazla DataBase güncelleme var ise
            if (SYNC == true)
                DBSERVER.dbserver_use = false;
            //birden fazla tabloda güncelleme var ise
            if (TRAN == true)
                DBSERVER.dbserver_active = false;
            if (DBTYPE == AppStaticStr.core_dbTypeMYSQL)
            {
                using (Mysql_dapper db = new Mysql_dapper(connstr: CONNSTR, usetransaction: false))
                {
                    if (DBSERVER.dbserver_id == 0)
                    {
                        long id = 0;
                        id = db.Insert<dbserver>(DBSERVER);
                        if (id != 0)
                            result = db.Get<dbserver>(id);
                    }
                    else
                    {
                        bool ok = db.Update<dbserver>(DBSERVER);
                        if (ok == true)
                            result = db.Get<dbserver>(DBSERVER.dbserver_id);
                        else
                            result = DBSERVER;
                    }
                }
            }
            AfterSavedbserver(DBSERVER: DBSERVER, DBTYPE: DBTYPE, CONNSTR: CONNSTR, SYNC: SYNC, TRAN: TRAN);
            return result;
        }
        public bool Deletedbserver(long ID, string DBTYPE, string CONNSTR, bool SYNC = false, bool TRAN = false)
        {
            bool result = false;
            BeforeDeletedbserver(ID, DBTYPE, CONNSTR, SYNC, TRAN);
            if (DBTYPE == AppStaticStr.core_dbTypeMYSQL)
            {
                dbserver etmp = Getdbserver(ID, DBTYPE, CONNSTR);
                //eğer birden fazla Database etkileniyor ise
                if (SYNC == true)
                    etmp.dbserver_use = false;
                //eğer birden fazla tablo etkileniyor ise
                if (TRAN == true)
                    etmp.dbserver_active = false;
                etmp.deleteddbserver_id = true;
                dbserver eresulttmp = Savedbserver(etmp, DBTYPE, CONNSTR);
                if (eresulttmp.deleteddbserver_id == true)
                    result = true;
            }
            AfterDeletedbserver(ID, DBTYPE, CONNSTR, SYNC, TRAN);
            return result;
        }
        public dbserver Getdbserver(long ID, string DBTYPE, string CONNSTR, bool ALL=false)
        {
            dbserver result = new dbserver();
            if (DBTYPE == AppStaticStr.core_dbTypeMYSQL)
            {
                using (Mysql_dapper db = new Mysql_dapper(connstr: CONNSTR, usetransaction: false))
                {                    result = db.Get<dbserver>(id: ID);
                    //senkron dışında ve silinenlerin dışındakileri getirmesi
                    if (ALL==false)
                        if ((result.dbserver_use == false) || (result.deleteddbserver_id == true) || (result.dbserver_active==false))
                            result = new dbserver();
                }
            }
            return result;
        }
        public List<dbserver> GetAlldbserver(string whereclause , string DBTYPE , string CONNSTR , bool ALL=false)
        {
            List<dbserver> result = new List<dbserver>();
            BeforeGetAlldbserver(whereclause, DBTYPE, CONNSTR, ALL);
            //senkron dışında ve silinenlerin dışındakileri getirmesi
            if (ALL == false)
            {
                info_dbserver info = new info_dbserver();
                whereclause += "AND " + info.dbserver_deleteddbserver_id + " = false AND " + info.dbserver_dbserver_use + " = true AND " + info.dbserver_dbserver_active + " = true";
            }
            if (DBTYPE == AppStaticStr.core_dbTypeMYSQL)
            {
                using (Mysql_dapper db = new Mysql_dapper(connstr: CONNSTR, usetransaction: false))
                {
                    result = db.GetAll<dbserver>(whereclause: whereclause).ToList();
                }            }            AfterGetAlldbserver(whereclause, DBTYPE, CONNSTR, ALL);
            return result;
        }
        public void BeforeSavedbserver(dbserver DBSERVER, string DBTYPE, string CONNSTR, bool SYNC, bool TRAN) { }
        public void AfterSavedbserver(dbserver DBSERVER, string DBTYPE, string CONNSTR, bool SYNC, bool TRAN) { }
        public void AfterDeletedbserver (long ID, string DBTYPE, string CONNSTR, bool SYNC, bool TRAN) { }
        public void BeforeDeletedbserver(long ID, string DBTYPE, string CONNSTR, bool SYNC, bool TRAN) { }
        public void BeforeGetdbserver(long ID, string DBTYPE, string CONNSTR, bool ALL) { }
        public void AfterGetdbserver(long ID, string DBTYPE, string CONNSTR, bool ALL) { }
        public void BeforeGetAlldbserver(string whereclause , string DBTYPE , string CONNSTR , bool ALL ) { }
        public void AfterGetAlldbserver(string whereclause, string DBTYPE, string CONNSTR, bool ALL) { }
    }

}