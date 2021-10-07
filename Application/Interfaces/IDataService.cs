using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IDataService
    {
        //users
        Task<int> UsersCreate(UsersModel model);
        Task UsersUpdate(UsersModel model);
        Task UsersDelete(int Id);
        Task<UsersModel> UsersGet(int Id);
        Task<List<UsersModel>> UsersGetAll();
        Task UsersChangePassword(int Id, string newPassword);
        Task<UsersModel> UsersLogin(string email, string password);

        //roles
        Task<int> RolesCreate(RolesModel model);
        Task RolesUpdate(RolesModel model);
        Task RolesDelete(int Id);
        Task<RolesModel> RolesGet(int Id);
        Task<List<RolesModel>> RolesGetAll();

        //roles
        Task<int> NewsCreate(NewsModel model);
        Task NewsUpdate(NewsModel model);
        Task NewsDelete(int Id);
        Task<NewsModel> NewsGet(int Id);
        Task<List<NewsModel>> NewsGetAll();

        //gaugeRecords
        Task<int> GaugeRecordsCreate(GaugeRecordsModel model);
        Task GaugeRecordsUpdate(GaugeRecordsModel model);
        Task GaugeRecordsDelete(int Id);
        Task GaugeRecordsApprove(GaugeRecordsModel model);
        Task<List<GaugeRecordsModel>> GaugeRecordsGet(int Id);
        Task<List<GaugeRecordsModel>> GaugeRecordsGetAll();

        //GaugeStation
        Task<int> GaugeStationCreate(GaugeStationModel model);
        Task GaugeStationUpdate(GaugeStationModel model);
        Task GaugeStationDelete(int Id);
        Task<GaugeStationModel> GaugeStationGet(int Id);
        Task<List<GaugeStationModel>> GaugeStationGetAll();
        Task<GaugeRecordsModel> GaugeStationGetRecords(int Id);

        //Staff
        Task<int> StaffCreate(StaffModel model);
        Task StaffUpdate(StaffModel model);
        Task StaffDelete(int Id);
        Task<StaffModel> StaffGet(int Id);
        Task<List<StaffModel>> StaffGetAll();

        //stations 
        Task<int> StationsCreate(StationsModel model);
        Task StationsUpdate(StationsModel model);
        Task StationsDelete(int Id);
        Task<StationsModel> StationsGet(int Id);
        Task<List<StationsModel>> StationsGetAll();
        Task<List<GaugeStationModel>> StationsGetGauge(int Id);
        Task<List<HistoricalDataModel>> StationsGetHistoricalDataYears(int Id);
        Task<List<HistoricalDataModel>> StationsGetHistoricalData(int id);


        //stationStats
        Task<int> StationStatisticsCreate(StationStatisticsModel model);
        Task StationStatisticsUpdate(StationStatisticsModel model);
        Task StationStatisticsDelete(int Id);
        Task<StationStatisticsModel> StationStatisticsGet(int Id);
        Task<List<StationStatisticsModel>> StationStatisticsGetAll();
    }
}
