using System.Collections.Generic;
using System.Linq;
using micro_services_dal;
using micro_services_share;
using micro_services_share.vModel;
using micro_services_share.Model;
using Newtonsoft.Json;
using micro_services_dal.Models.zoradamlar_com_db_mic_user;

namespace micro_services_bus.zoradamlar_com_db_mic_user
{
    public partial class Op_lang
    {
        public lang Savelang(lang LANG, allofusers ALLOFUSERS, Mysql_dapper DB_MYSQL = null, bool SYNC = false, bool TRAN = false)
        {
            string connstr = GetConnStr(ALLOFUSERS);
            lang result = new lang();
            BeforeSavelang(LANG: LANG, ALLOFUSERS, DB_MYSQL:DB_MYSQL, SYNC:SYNC, TRAN: TRAN);
            //eğer birden fazla DataBase güncelleme var ise
            if (SYNC == true)
                LANG.lang_use = false;
            //birden fazla tabloda güncelleme var ise
            if (TRAN == true)
                LANG.lang_active = false;
            if ( ALLOFUSERS.appdatabase_type == AppStaticStr.core_dbTypeMYSQL)
            {
                if (DB_MYSQL == null)
                {
                   using (Mysql_dapper db = new Mysql_dapper(connstr: connstr, usetransaction: false))
                   {
                        if (LANG.lang_id == 0)
                       {
                            long id = 0;
                            id = db.Insert<lang>(LANG);
                           if (id != 0)
                             result = db.Get<lang>(id);
                       }
                       else
                       {
                         bool ok = db.Update<lang>(LANG);
                           if (ok == true)
                             result = db.Get<lang>(LANG.lang_id);
                           else
                             result = LANG;
                       }
                   }
                }
                else
                {
                   Mysql_dapper db = DB_MYSQL;
                        if (LANG.lang_id == 0)
                       {
                            long id = 0;
                            id = db.Insert<lang>(LANG);
                           if (id != 0)
                             result = db.Get<lang>(id);
                       }
                       else
                       {
                         bool ok = db.Update<lang>(LANG);
                           if (ok == true)
                             result = db.Get<lang>(LANG.lang_id);
                           else
                             result = LANG;
                       }
                }
            }
            AfterSavelang(LANG: LANG, ALLOFUSERS,  DB_MYSQL:DB_MYSQL, SYNC: SYNC, TRAN: TRAN);
            return result;
        }
        public bool Deletelang(long ID, allofusers ALLOFUSERS, Mysql_dapper DB_MYSQL = null, bool SYNC = false, bool TRAN = false)
        {
            bool result = false;
            BeforeDeletelang(ID, ALLOFUSERS,  DB_MYSQL:DB_MYSQL, SYNC, TRAN);
            if (ALLOFUSERS.appdatabase_type == AppStaticStr.core_dbTypeMYSQL)
            {
                lang etmp = Getlang(ID, ALLOFUSERS);
                //eğer birden fazla Database etkileniyor ise
                if (SYNC == true)
                    etmp.lang_use = false;
                //eğer birden fazla tablo etkileniyor ise
                if (TRAN == true)
                    etmp.lang_active = false;
                etmp.deletedlang_id = true;
                lang eresulttmp = Savelang(LANG:etmp, ALLOFUSERS:ALLOFUSERS, DB_MYSQL:DB_MYSQL, SYNC:SYNC,TRAN:TRAN);
                if (eresulttmp.deletedlang_id == true)
                    result = true;
            }
            AfterDeletelang(ID, ALLOFUSERS,  DB_MYSQL:DB_MYSQL, SYNC, TRAN);
            return result;
        }
        public lang Getlang(long ID, allofusers ALLOFUSERS, bool ALL=false)
        {
            lang result = new lang();
            string connstr = GetConnStr(ALLOFUSERS);
            if (ALLOFUSERS.appdatabase_type == AppStaticStr.core_dbTypeMYSQL)
            {
                using (Mysql_dapper db = new Mysql_dapper(connstr: connstr, usetransaction: false))
                {                    result = db.Get<lang>(id: ID);
                    //senkron dişinda ve silinenlerin dişindakileri getirmesi
                    if (ALL==false)
                        if ((result.lang_use == false) || (result.deletedlang_id == true) || (result.lang_active==false))
                            result = new lang();
                }
            }
            return result;
        }
        public List<lang> GetAlllang(string whereclause , allofusers ALLOFUSERS, bool ALL=false)
        {
            List<lang> result = new List<lang>();
            string connstr = GetConnStr(ALLOFUSERS);
            BeforeGetAlllang(whereclause, ALLOFUSERS, ALL);
            //senkron dişinda ve silinenlerin dişindakileri getirmesi
            if (ALL == false)
            {
                info_lang info = new info_lang();
                whereclause += " AND " + info.lang_deletedlang_id + " = false AND " + info.lang_lang_use + " = true AND " + info.lang_lang_active + " = true";
            }
            if (ALLOFUSERS.appdatabase_type == AppStaticStr.core_dbTypeMYSQL)
            {
                using (Mysql_dapper db = new Mysql_dapper(connstr, usetransaction: false))
                {
                    result = db.GetAll<lang>(whereclause: whereclause).ToList();
                }            }            AfterGetAlllang(whereclause, ALLOFUSERS, ALL);
            return result;
        }
        public void BeforeSavelang(lang LANG, allofusers ALLOFUSERS, Mysql_dapper DB_MYSQL, bool SYNC, bool TRAN) { }
        public void AfterSavelang(lang LANG, allofusers ALLOFUSERS, Mysql_dapper DB_MYSQL, bool SYNC, bool TRAN) { }
        public void AfterDeletelang (long ID, allofusers ALLOFUSERS, Mysql_dapper DB_MYSQL, bool SYNC, bool TRAN) { }
        public void BeforeDeletelang(long ID, allofusers ALLOFUSERS, Mysql_dapper DB_MYSQL, bool SYNC, bool TRAN) { }
        public void BeforeGetlang(long ID, allofusers ALLOFUSERS, bool ALL) { }
        public void AfterGetlang(long ID, allofusers ALLOFUSERS, bool ALL) { }
        public void BeforeGetAlllang(string whereclause , allofusers ALLOFUSERS, bool ALL ) { }
        public void AfterGetAlllang(string whereclause, allofusers ALLOFUSERS, bool ALL) { }
        public string Single_crud (cRequest request, allofusers e_aou, Mysql_dapper DB_MYSQL=null)
        {
             string result = AppStaticStr.msg0040Hata;
             #region gelen paket içinden yapilacak işlemin bilgilerinin alinmasi
             List<ex_data> l_ed_opt = request.data_ex.Where(w => w.info == AppStaticStr.SrvOpt).ToList();
             if (l_ed_opt == null) return result;
             if (l_ed_opt.Count != 1) return result;
             #endregion gelen paket içinden yapilacak işlemin bilgilerinin alinmasi
             if (l_ed_opt[0].value==AppStaticStr.SingleCrudSave)
                 {
                     lang ent = JsonConvert.DeserializeObject<lang>(request.data);
                     lang save_ent = Savelang(ent, e_aou, DB_MYSQL, false, false);
                     cResponse res = new cResponse()
                     {
                         message_code = AppStaticInt.msg001Succes,
                         message = AppStaticStr.msg0045OK,
                         data = JsonConvert.SerializeObject(save_ent),
                         token = request.token
                     };
                     result = JsonConvert.SerializeObject(res);
                 }
             if (l_ed_opt[0].value==AppStaticStr.SingleCrudDelete)
             {
                 lang ent = JsonConvert.DeserializeObject<lang>(request.data);
                 bool resu = Deletelang (ID: ent.lang_id, ALLOFUSERS: e_aou, DB_MYSQL:DB_MYSQL ,SYNC: false, TRAN: false);
                 if (resu == true)
                 {
                     cResponse res = new cResponse()
                     {
                         message_code = AppStaticInt.msg001Succes,
                         message = AppStaticStr.msg0045OK,
                         data = resu.ToString(),
                         token = request.token
                     };
                     result = JsonConvert.SerializeObject(res);
                 }
             }
             if (l_ed_opt[0].value==AppStaticStr.SingleCrudGet)
             {
                 int ID = 0;
                 int.TryParse(request.data, out ID);
                 lang ent = Getlang(ID: ID,ALLOFUSERS:e_aou, ALL:false);
                 if (ent!=null)
                 {
                     if (ent.lang_id==ID)
                     {
                         cResponse res = new cResponse()
                         {
                         message_code = AppStaticInt.msg001Succes,
                         data = JsonConvert.SerializeObject(ent),
                         token = request.token
                         };
                         result = JsonConvert.SerializeObject(res);
                     }
                 }
             }
             if (l_ed_opt[0].value==AppStaticStr.SingleCrudGetAll)
             {
                 List<lang> ent = GetAlllang(whereclause:request.data, ALLOFUSERS: e_aou, ALL: false);
                 if (ent != null)
                 {
                     if (ent.Count>0)
                     {
                         cResponse res = new cResponse()
                         {
                             message_code = AppStaticInt.msg001Succes,
                             message = AppStaticStr.msg0045OK,
                             data = JsonConvert.SerializeObject(ent),
                             token = request.token
                         };
                         result = JsonConvert.SerializeObject(res);
                     }
                 }
             }
             if (l_ed_opt[0].value==AppStaticStr.SingleCrudGetAll_true)
             {
                 List<lang> ent = GetAlllang(whereclause:request.data, ALLOFUSERS: e_aou, ALL: true);
                 if (ent != null)
                 {
                     if (ent.Count>0)
                     {
                         cResponse res = new cResponse()
                         {
                             message_code = AppStaticInt.msg001Succes,
                             message = AppStaticStr.msg0045OK,
                             data = JsonConvert.SerializeObject(ent),
                             token = request.token
                         };
                         result = JsonConvert.SerializeObject(res);
                     }
                 }
             }
             return result;
        }
        public string GetConnStr (allofusers ALLOFUSERS)

        {
            string result = string.Empty;
            if (ALLOFUSERS.projects_id == AppStaticInt.ProjectCodeCore)
                result = ALLOFUSERS.appdatabase_connstr;
            long db_ID = 0;
            long.TryParse(ALLOFUSERS.company_dbserver_id.ToString(), out db_ID);
            if (db_ID == 0)
                result = ALLOFUSERS.appdatabase_connstr;
            else
                result = ALLOFUSERS.dbserver_adrr;
            return result;
        }
    }

}
