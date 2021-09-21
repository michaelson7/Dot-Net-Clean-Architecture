using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrustructure.StoredProcedures
{
    public class StoredProceduresPaths
    {
        public static string baseValue = "dbo.";

        //users
        public string UsersCreate = baseValue + "UsersCreate";
        public string UsersUpdate = baseValue + "UsersUpdate";
        public string UsersDelete = baseValue + "UsersDelete";
        public string UsersGet = baseValue + "UsersGet";
        public string UsersGetAll = baseValue + "UsersGetAll";
        public string UsersLogin = baseValue + "UsersLogin";
        public string UsersGetRole = baseValue + "UsersGetRole";
        public string UsersChangePassword = baseValue + "UsersChangePassword";

        //roles
        public string RolesCreate = baseValue + "RolesCreate";
        public string RolesUpdate = baseValue + "RolesUpdate";
        public string RolesDelete = baseValue + "RolesDelete";
        public string RolesGet = baseValue + "RolesGet";
        public string RolesGetAll = baseValue + "RolesGetAll";

        //roles
        public string NewsCreate = baseValue + "NewsCreate";
        public string NewsUpdate = baseValue + "NewsUpdate";
        public string NewsDelete = baseValue + "NewsDelete";
        public string NewsGet = baseValue + "NewsGet";
        public string NewsGetAll = baseValue + "NewsGetAll";

        //gaugeRecords
        public string GaugeRecordsCreate = baseValue + "GaugeRecordsCreate";
        public string GaugeRecordsUpdate = baseValue + "GaugeRecordsUpdate";
        public string GaugeRecordsDelete = baseValue + "GaugeRecordsDelete";
        public string GaugeRecordsGet = baseValue + "GaugeRecordsGet";
        public string GaugeRecordsGetAll = baseValue + "GaugeRecordsGetAll";
        public string GaugeRecordsApprove = baseValue + "GaugeRecordsApprove";

        //GaugeStation
        public string GaugeStationCreate = baseValue + "GaugeStationCreate";
        public string GaugeStationUpdate = baseValue + "GaugeStationUpdate";
        public string GaugeStationDelete = baseValue + "GaugeStationDelete";
        public string GaugeStationGet = baseValue + "GaugeStationGet";
        public string GaugeStationGetAll = baseValue + "GaugeStationGetAll";
        public string GaugeStationGetRecords = baseValue + "GaugeStationGetRecords";

        //Staff
        public string StaffCreate = baseValue + "StaffCreate";
        public string StaffUpdate = baseValue + "StaffUpdate";
        public string StaffDelete = baseValue + "StaffDelete";
        public string StaffGet = baseValue + "StaffGet";
        public string StaffGetAll = baseValue + "StaffGetAll";

        //stations
        public string StationsGetGauge = baseValue + "StationsGetGauge";
        public string StationsCreate = baseValue + "StationsCreate";
        public string StationsUpdate = baseValue + "StationsUpdate";
        public string StationsDelete = baseValue + "StationsDelete";
        public string StationsGet = baseValue + "StationsGet";
        public string StationsGetAll = baseValue + "StationsGetAll";

        //stationStats
        public string StationStatisticsCreate = baseValue + "StationStatisticsCreate";
        public string StationStatisticsUpdate = baseValue + "StationStatisticsUpdate";
        public string StationStatisticsDelete = baseValue + "StationStatisticsDelete";
        public string StationStatisticsGet = baseValue + "StationStatisticsGet";
        public string StationStatisticsGetAll = baseValue + "StationStatisticsGetAll";
    }
}
