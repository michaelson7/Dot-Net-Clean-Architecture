using Application.Interfaces;
using Domain.Models;
using Infrustructure.StoredProcedures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrustructure.Services
{
    public class DataService : IDataService
    {
        private readonly IDataAccess _db;
        private const string connectionStringName = "SqlDb";
        public StoredProceduresPaths _sp = new StoredProceduresPaths();

        public DataService(IDataAccess db)
        {
            _db = db;
        }

        public async Task<int> UsersCreate(UsersModel model)
        {
            int output = 0;
            output = await _db.SaveDataAsync(_sp.UsersCreate,
                                             new
                                             {
                                                 FirstName = model.FirstName,
                                                 LastName = model.LastName,
                                                 Email = model.Email,
                                                 Password = model.Password,
                                                 RoleId = model.RoleId,
                                             },
                                             connectionStringName,
                                             true);
            return output;
        }

        public async Task UsersUpdate(UsersModel model)
        {
            await _db.SaveDataAsync(_sp.UsersUpdate,
                                             new
                                             {
                                                 Id = model.Id,
                                                 FirstName = model.FirstName,
                                                 LastName = model.LastName,
                                                 Email = model.Email,
                                                 Password = model.Password,
                                                 RoleId = model.RoleId,
                                             },
                                             connectionStringName,
                                             true);
        }

        public async Task UsersDelete(int Id)
        {
            await _db.SaveDataAsync(_sp.UsersDelete,
                                              new
                                              {
                                                  Id = Id
                                              },
                                              connectionStringName,
                                              true);
        }

        public async Task<UsersModel> UsersGet(int Id)
        {
            UsersModel output = new UsersModel();
            var list = await _db.LoadDataAsync<UsersModel, dynamic>(_sp.UsersGet,
                                                 new
                                                 { Id = Id },
                                                 connectionStringName,
                                                 true);
            output = list.FirstOrDefault();
            if (output != null)
            {
                output.RolesModel = await RolesGet(output.RoleId);
            }
            return output;
        }

        public async Task<List<UsersModel>> UsersGetAll()
        {
            List<UsersModel> output = new List<UsersModel>();
            output = await _db.LoadDataAsync<UsersModel, dynamic>(_sp.UsersGetAll,
                                                 new
                                                 { },
                                                 connectionStringName,
                                                 true);
            if (output != null)
            {
                foreach (var data in output)
                {
                    data.RolesModel = await RolesGet(data.RoleId);
                }
            }
            return output;
        }

        public async Task UsersChangePassword(int Id, string newPassword)
        {
            await _db.SaveDataAsync(_sp.UsersChangePassword,
                                            new
                                            {
                                                Id = Id,
                                                Password = newPassword
                                            },
                                            connectionStringName,
                                            true);
        }

        public async Task<UsersModel> UsersLogin(string email, string password)
        {
            UsersModel output = new UsersModel();
            var list = await _db.LoadDataAsync<UsersModel, dynamic>(_sp.UsersLogin,
                                                 new
                                                 {
                                                     Email = email,
                                                     Password = password
                                                 },
                                                 connectionStringName,
                                                 true);
            output = list.FirstOrDefault();
            if (output != null)
            {
                output.RolesModel = await RolesGet(output.RoleId);
            }
            return output;
        }

        public async Task<int> RolesCreate(RolesModel model)
        {
            int output = 0;
            output = await _db.SaveDataAsync(_sp.RolesCreate,
                                             new
                                             {
                                                 Title = model.Title
                                             },
                                             connectionStringName,
                                             true);
            return output;
        }

        public async Task RolesUpdate(RolesModel model)
        {
            await _db.SaveDataAsync(_sp.RolesUpdate,
                                             new
                                             {
                                                 Id = model.Id,
                                                 Title = model.Title
                                             },
                                             connectionStringName,
                                             true);
        }

        public async Task RolesDelete(int Id)
        {
            await _db.SaveDataAsync(_sp.RolesDelete,
                                              new
                                              {
                                                  Id = Id
                                              },
                                              connectionStringName,
                                              true);
        }

        public async Task<RolesModel> RolesGet(int Id)
        {
            RolesModel output = new RolesModel();
            var list = await _db.LoadDataAsync<RolesModel, dynamic>(_sp.RolesGet,
                                                 new
                                                 { Id = Id },
                                                 connectionStringName,
                                                 true);
            output = list.FirstOrDefault();
            return output;
        }

        public async Task<List<RolesModel>> RolesGetAll()
        {
            List<RolesModel> output = new List<RolesModel>();
            output = await _db.LoadDataAsync<RolesModel, dynamic>(_sp.RolesGetAll,
                                                 new
                                                 { },
                                                 connectionStringName,
                                                 true);
            return output;
        }

        public async Task<int> NewsCreate(NewsModel model)
        {
            int output = 0;
            output = await _db.SaveDataAsync(_sp.NewsCreate,
                                             new
                                             {
                                                 Heading = model.Heading,
                                                 ImagePath = model.ImagePath,
                                                 Message = model.Message,
                                                 UserId = model.UserId
                                             },
                                             connectionStringName,
                                             true);
            return output;
        }

        public async Task NewsUpdate(NewsModel model)
        {
            await _db.SaveDataAsync(_sp.NewsUpdate,
                                             new
                                             {
                                                 Id = model.Id,
                                                 Heading = model.Heading,
                                                 ImagePath = model.ImagePath,
                                                 Message = model.Message
                                             },
                                             connectionStringName,
                                             true);
        }

        public async Task NewsDelete(int Id)
        {
            await _db.SaveDataAsync(_sp.NewsDelete,
                                              new
                                              {
                                                  Id = Id
                                              },
                                              connectionStringName,
                                              true);
        }

        public async Task<NewsModel> NewsGet(int Id)
        {
            NewsModel output = new NewsModel();
            var list = await _db.LoadDataAsync<NewsModel, dynamic>(_sp.NewsGet,
                                                 new
                                                 { Id = Id },
                                                 connectionStringName,
                                                 true);
            output = list.FirstOrDefault();
            if (output != null)
            {
                var data = await UsersGet(output.UserId);
                if (data != null)
                {
                    output.UsersModel = data;
                }
            }
            return output;
        }

        public async Task<List<NewsModel>> NewsGetAll()
        {
            List<NewsModel> output = new List<NewsModel>();
            output = await _db.LoadDataAsync<NewsModel, dynamic>(_sp.NewsGetAll,
                                                 new
                                                 { },
                                                 connectionStringName,
                                                 true);
            foreach (var item in output)
            {
                var userData = await UsersGet(item.UserId);
                if (userData != null)
                {
                    item.UsersModel = userData;
                }
            }
            return output;
        }

        public async Task<int> GaugeRecordsCreate(GaugeRecordsModel model)
        {
            int output = 0;
            output = await _db.SaveDataAsync(_sp.GaugeRecordsCreate,
                                             new
                                             {
                                                 UploaderId = model.UploaderId,
                                                 Imagepath = model.Imagepath,
                                                 GPSLocation = model.GPSLocation,
                                                 Waterlevel = model.Waterlevel,
                                                 Temperature = model.Temperature,
                                                 RiverFlow = model.RiverFlow,
                                                 GaugeId = model.GaugeId
                                             },
                                             connectionStringName,
                                             true);
            return output;
        }

        public async Task GaugeRecordsUpdate(GaugeRecordsModel model)
        {
            await _db.SaveDataAsync(_sp.GaugeRecordsUpdate,
                                              new
                                              {
                                                  Id = model.Id,
                                                  Imagepath = model.Imagepath,
                                                  GPSLocation = model.GPSLocation,
                                                  Waterlevel = model.Waterlevel,
                                                  Temperature = model.Temperature,
                                                  GaugeId = model.GaugeId,
                                                  RiverFlow = model.RiverFlow,
                                                  Approval = model.Approval,
                                                  ApproverId = model.ApproverId,
                                              },
                                              connectionStringName,
                                              true);
        }

        public async Task GaugeRecordsDelete(int Id)
        {
            await _db.SaveDataAsync(_sp.GaugeRecordsDelete,
                                            new
                                            {
                                                Id = Id
                                            },
                                            connectionStringName,
                                            true);
        }

        public async Task GaugeRecordsApprove(GaugeRecordsModel model)
        {
            await _db.SaveDataAsync(_sp.GaugeRecordsApprove,
                                            new
                                            {
                                                Id = model.Id,
                                                Approval = model.Approval,
                                                ApproverId = model.ApproverId
                                            },
                                            connectionStringName,
                                            true);
        }

        public async Task<List<GaugeRecordsModel>> GaugeRecordsGet(int Id)
        {
            List<GaugeRecordsModel> output = new List<GaugeRecordsModel>();
            output = await _db.LoadDataAsync<GaugeRecordsModel, dynamic>(_sp.GaugeRecordsGet,
                                                 new
                                                 {
                                                     Id = Id
                                                 },
                                                 connectionStringName,
                                                 true);

            if (output != null)
            {
                foreach (var data in output)
                {
                    var userData = await UsersGet(data.UploaderId);
                    var gaugeData = await GaugeStationGet(data.GaugeId);
                    UsersModel approverData = null;
                    if (data.Approval)
                    {
                        approverData = await UsersGet(data.ApproverId);
                    }

                    if (userData != null)
                    {
                        data.UploaderModel = userData;
                    }

                    if (gaugeData != null)
                    {
                        data.GaugeStationModel = gaugeData;
                    }
                    if (approverData != null)
                    {
                        data.ApproverModel = approverData;
                    }
                }
            }
            return output;
        }

        public async Task<List<GaugeRecordsModel>> GaugeRecordsGetAll()
        {
            List<GaugeRecordsModel> output = new List<GaugeRecordsModel>();
            output = await _db.LoadDataAsync<GaugeRecordsModel, dynamic>(_sp.GaugeRecordsGetAll,
                                                 new
                                                 { },
                                                 connectionStringName,
                                                 true);
            if (output != null)
            {
                foreach (var data in output)
                {
                    data.UploaderModel = await UsersGet(data.UploaderId);
                    data.GaugeStationModel = await GaugeStationGet(data.GaugeId);
                    if (data.Approval)
                    {
                        data.ApproverModel = await UsersGet(data.ApproverId);
                    }
                }
            }
            return output;
        }

        public async Task<int> GaugeStationCreate(GaugeStationModel model)
        {
            int output = 0;
            output = await _db.SaveDataAsync(_sp.GaugeStationCreate,
                                             new
                                             {
                                                 Title = model.Title,
                                                 StationId = model.StationId
                                             },
                                             connectionStringName,
                                             true);
            return output;
        }

        public async Task GaugeStationUpdate(GaugeStationModel model)
        {
            await _db.SaveDataAsync(_sp.GaugeStationUpdate,
                                             new
                                             {
                                                 Id = model.Id,
                                                 Title = model.Title,
                                                 StationId = model.StationId
                                             },
                                             connectionStringName,
                                             true);
        }

        public async Task GaugeStationDelete(int Id)
        {
            await _db.SaveDataAsync(_sp.GaugeStationDelete,
                                           new
                                           {
                                               Id = Id
                                           },
                                           connectionStringName,
                                           true);
        }

        public async Task<GaugeStationModel> GaugeStationGet(int Id)
        {
            GaugeStationModel output = new GaugeStationModel();
            var list = await _db.LoadDataAsync<GaugeStationModel, dynamic>(_sp.GaugeStationGet,
                                                 new
                                                 {
                                                     Id = Id
                                                 },
                                                 connectionStringName,
                                                 true);
            output = list.FirstOrDefault();
            if (output != null)
            {
                output.StationsModel = await StationsGet(output.StationId);
            }
            return output;
        }

        public async Task<List<GaugeStationModel>> GaugeStationGetAll()
        {
            List<GaugeStationModel> output = new List<GaugeStationModel>();
            output = await _db.LoadDataAsync<GaugeStationModel, dynamic>(_sp.GaugeStationGetAll,
                                                 new
                                                 { },
                                                 connectionStringName,
                                                 true);
            if (output != null)
            {
                foreach (var data in output)
                {
                    var dataList = await StationsGet(data.StationId);

                    if (dataList != null)
                    {
                        data.StationsModel = dataList;
                    }
                }
            }
            return output;
        }

        public async Task<GaugeRecordsModel> GaugeStationGetRecords(int Id)
        {
            GaugeRecordsModel output = new GaugeRecordsModel();
            var list = await _db.LoadDataAsync<GaugeRecordsModel, dynamic>(_sp.GaugeStationGetRecords,
                                                 new
                                                 {
                                                     Id = Id
                                                 },
                                                 connectionStringName,
                                                 true);
            output = list.FirstOrDefault();
            if (output != null)
            {
                output.UploaderModel = await UsersGet(output.UploaderId);
                output.GaugeStationModel = await GaugeStationGet(output.GaugeId);
                if (output.Approval)
                {
                    output.ApproverModel = await UsersGet(output.ApproverId);
                }
            }
            return output;

        }

        public async Task<int> StaffCreate(StaffModel model)
        {
            int output = 0;
            output = await _db.SaveDataAsync(_sp.StaffCreate,
                                             new
                                             {
                                                 Salary = model.Salary,
                                                 UserId = model.UserId,
                                                 StationId = model.StationId,
                                             },
                                             connectionStringName,
                                             true);
            return output;
        }

        public async Task StaffUpdate(StaffModel model)
        {
            await _db.SaveDataAsync(_sp.StaffUpdate,
                                              new
                                              {
                                                  Id = model.Id,
                                                  Salary = model.Salary,
                                                  StationId = model.StationId,
                                              },
                                              connectionStringName,
                                              true);
        }

        public async Task StaffDelete(int Id)
        {
            await _db.SaveDataAsync(_sp.StaffDelete,
                                             new
                                             {
                                                 Id = Id
                                             },
                                             connectionStringName,
                                             true);
        }

        public async Task<StaffModel> StaffGet(int Id)
        {
            StaffModel output = new StaffModel();
            var list = await _db.LoadDataAsync<StaffModel, dynamic>(_sp.StaffGet,
                                                 new
                                                 { Id = Id },
                                                 connectionStringName,
                                                 true);
            output = list.FirstOrDefault();
            if (output != null)
            {
                output.StationsModel = await StationsGet(output.StationId);
                output.UsersModel = await UsersGet(output.UserId);
            }
            return output;
        }

        public async Task<List<StaffModel>> StaffGetAll()
        {
            List<StaffModel> output = new List<StaffModel>();
            output = await _db.LoadDataAsync<StaffModel, dynamic>(_sp.StaffGetAll,
                                                 new
                                                 { },
                                                 connectionStringName,
                                                 true);

            if (output != null)
            {
                foreach (var data in output)
                {
                    data.StationsModel = await StationsGet(data.StationId);
                    data.UsersModel = await UsersGet(data.UserId);
                }
            }
            return output;
        }

        public async Task<int> StationsCreate(StationsModel model)
        {
            int output = 0;
            output = await _db.SaveDataAsync(_sp.StationsCreate,
                                             new
                                             {
                                                 Title = model.Title,
                                                 ImagePath = model.ImagePath,

                                             },
                                             connectionStringName,
                                             true);
            return output;
        }

        public async Task StationsUpdate(StationsModel model)
        {
            await _db.SaveDataAsync(_sp.StationsUpdate,
                                           new
                                           {
                                               Id = model.Id,
                                               Title = model.Title,
                                               ImagePath = model.ImagePath,
                                           },
                                           connectionStringName,
                                           true);
        }

        public async Task StationsDelete(int Id)
        {
            await _db.SaveDataAsync(_sp.StationsDelete,
                                         new
                                         {
                                             Id = Id
                                         },
                                         connectionStringName,
                                         true);
        }

        public async Task<StationsModel> StationsGet(int Id)
        {
            StationsModel output = new StationsModel();
            var list = await _db.LoadDataAsync<StationsModel, dynamic>(_sp.StationsGet,
                                                 new
                                                 { Id = Id },
                                                 connectionStringName,
                                                 true);
            output = list.FirstOrDefault();
            if (output != null)
            {
                var dataList = await StationStatisticsGet(output.Id);
                if (dataList != null)
                {
                    output.StationStatisticsModel = dataList;
                }

            }
            return output;
        }

        public async Task<List<StationsModel>> StationsGetAll()
        {
            List<StationsModel> output = new List<StationsModel>();
            output = await _db.LoadDataAsync<StationsModel, dynamic>(_sp.StationsGetAll,
                                                 new
                                                 { },
                                                 connectionStringName,
                                                 true);
            if (output != null)
            {
                foreach (var item in output)
                {

                    var dataList = await StationStatisticsGet(item.Id);
                    if (dataList != null)
                    {
                        item.StationStatisticsModel = dataList;
                    }
                }
            }
            return output;
        }

        public async Task<List<GaugeStationModel>> StationsGetGauge(int Id)
        {
            List<GaugeStationModel> output = new List<GaugeStationModel>();
            output = await _db.LoadDataAsync<GaugeStationModel, dynamic>(_sp.StationsGetGauge,
                                                 new
                                                 { Id = Id },
                                                 connectionStringName,
                                                 true);
            foreach (var data in output)
            {
                data.StationsModel = await StationsGet(data.StationId);
            }
            return output;
        }

        public async Task<int> StationStatisticsCreate(StationStatisticsModel model)
        {
            int output = 0;
            output = await _db.SaveDataAsync(_sp.StationStatisticsCreate,
                                             new
                                             {
                                                 Location = model.Location,
                                                 StationId = model.StationId,
                                                 Coordinates = model.Coordinates
                                             },
                                             connectionStringName,
                                             true);

            return output;
        }

        public async Task StationStatisticsUpdate(StationStatisticsModel model)
        {
            await _db.SaveDataAsync(_sp.StationStatisticsUpdate,
                                             new
                                             {
                                                 Id = model.Id,
                                                 Location = model.Location,
                                                 StationId = model.StationId,
                                                 Coordinates = model.Coordinates
                                             },
                                             connectionStringName,
                                             true);
        }

        public async Task StationStatisticsDelete(int Id)
        {
            await _db.SaveDataAsync(_sp.StationStatisticsDelete,
                                             new
                                             {
                                                 Id = Id
                                             },
                                             connectionStringName,
                                             true);
        }

        public async Task<StationStatisticsModel> StationStatisticsGet(int Id)
        {
            StationStatisticsModel output = new StationStatisticsModel();
            var list = await _db.LoadDataAsync<StationStatisticsModel, dynamic>(_sp.StationStatisticsGet,
                                                 new
                                                 { Id = Id },
                                                 connectionStringName,
                                                 true);
            output = list.FirstOrDefault();
            return output;
        }

        public async Task<List<StationStatisticsModel>> StationStatisticsGetAll()
        {
            List<StationStatisticsModel> output = new List<StationStatisticsModel>();
            output = await _db.LoadDataAsync<StationStatisticsModel, dynamic>(_sp.StationStatisticsGetAll,
                                                new
                                                { },
                                                connectionStringName,
                                                true);
            return output;
        }


    }
}
