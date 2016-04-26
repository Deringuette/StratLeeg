using StrategicLegionDatabaseFacade.Communication;
using System;
using System.Collections.Generic;
using StrategicLegionDatabaseModels;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using StrategicLegionDatabaseFacade.Communication.Queries.Checklists;
using StrategicLegionDatabaseFacade.Communication.ResponseModels.Checklists;
using StrategicLegionDatabaseModels.Models.Checklists;
using System.Configuration;
using StrategicLegionDatabaseFacade.Communication.Commands.Checklists;
using StrategicLegionDatabaseModels.Models.Counters;
using StrategicLegionDatabaseModels.Models.Images;
using StrategicLegionDatabaseModels.Models.Notepads;
using StrategicLegionDatabaseModels.Models.Whiteboards;
using StrategicLegionDatabaseFacade.Communication.Commands.Notepads;
using StrategicLegionDatabaseFacade.Communication.Commands.Whiteboards;
using StrategicLegionDatabaseFacade.Communication.Commands.Images;
using StrategicLegionDatabaseFacade.Communication.Commands.Counters;
using StrategicLegionDatabaseFacade.Communication.Queries.Counters;
using StrategicLegionDatabaseFacade.Communication.Queries.Images;
using StrategicLegionDatabaseFacade.Communication.Queries.Whiteboards;
using StrategicLegionDatabaseFacade.Communication.Queries.Notepads;

namespace StrategicLegionDatabaseFacade.Presentation
{
    /// <summary>
    /// Class handling all of the communication with the Database.
    /// </summary>
    public class DatabaseRequestsFacade : IDatabaseRequestsFacade
    {
        public readonly ISqlHelper SqlHelper;

        public readonly IQueryResultParser QueryResultParser;

        public IDbCommands Commands { get; private set; }

        public IDbQueries Queries { get; private set; }

        public string Connection
        {
            get { return SqlHelper.Greeting; }
        }

        private static SqlHelper DevelopmentMachineConnectionString
        {
            get
            {
#if DEBUG
                return new SqlHelper(ConfigurationManager.ConnectionStrings["SLDevelopmentDatabase"].ConnectionString);

#else
            return new SqlHelper(ConfigurationManager.ConnectionStrings["StrategicLegionDatabase"].ConnectionString);
#endif

            }
        }

        public DatabaseRequestsFacade()
            : this(DevelopmentMachineConnectionString)
        {
        }

        public DatabaseRequestsFacade(ISqlHelper sqlHelper)
        {
            SqlHelper = sqlHelper;
            QueryResultParser = new QueryResultParser();

            Commands = new DbCommands(this);
            Queries = new DbQueries(this);
        }

        public DatabaseRequestsFacade(ISqlHelper sqlHelper, IQueryResultParser queryResultParser)
        {
            SqlHelper = sqlHelper;
            QueryResultParser = queryResultParser;

            Commands = new DbCommands(this);
            Queries = new DbQueries(this);
        }


        public class DbCommands : IDbCommands
        {
            private readonly DatabaseRequestsFacade Container;

            public DbCommands(DatabaseRequestsFacade container)
            {
                Container = container;
            }

            //Checklists
            public ICommandResult InsertChecklistEntry(InsertChecklistEntry insertChecklistEntry)
            {
                var insertChecklistEntryCommand = new InsertChecklistEntryCommand();

                insertChecklistEntryCommand.BuildParamsRequest(insertChecklistEntry);
                insertChecklistEntryCommand.AddOutputParameter("@ChecklistId", SqlDbType.Int);

                return Container.SqlHelper.SendCommand(insertChecklistEntryCommand);
            }



            // Checklist Groups
            public ICommandResult InsertChecklistGroupEntry(InsertChecklistGroupEntry insertChecklistGroupEntry)
            {
                var insertChecklistGroupEntryCommand = new InsertChecklistGroupEntryCommand();
                insertChecklistGroupEntryCommand.BuildParamsRequest(insertChecklistGroupEntry);
                insertChecklistGroupEntryCommand.AddOutputParameter("@ChecklistGroupId", SqlDbType.Int);

                return Container.SqlHelper.SendCommand(insertChecklistGroupEntryCommand);
            }


            public ICommandResult UpdateChecklistGroupEntry(UpdateChecklistGroupEntry updateChecklistGroupEntry)
            {
                var UpdateChecklistGroupCommand = new UpdateChecklistGroupCommand();

                UpdateChecklistGroupCommand.BuildParamsRequest(updateChecklistGroupEntry);

                return Container.SqlHelper.SendCommand(UpdateChecklistGroupCommand);
            }




            // Checklist Items
            public ICommandResult InsertChecklistItemEntry(InsertChecklistItemEntry insertChecklistItemEntry)
            {
                var insertChecklistItemEntryCommand = new InsertChecklistItemEntryCommand();
                insertChecklistItemEntryCommand.BuildParamsRequest(insertChecklistItemEntry);
                insertChecklistItemEntryCommand.AddOutputParameter("@ChecklistItemId", SqlDbType.Int);

                return Container.SqlHelper.SendCommand(insertChecklistItemEntryCommand);
            }


            public ICommandResult UpdateChecklistItemEntry(UpdateChecklistItemEntry updateChecklistItemEntry)
            {
                var UpdateChecklistItemCommand = new UpdateChecklistItemCommand();

                UpdateChecklistItemCommand.BuildParamsRequest(updateChecklistItemEntry);

                return Container.SqlHelper.SendCommand(UpdateChecklistItemCommand);
            }


            //Counters
            public ICommandResult InsertCounterEntry(InsertCounterEntry insertCounterEntry)
            {
                var insertCounterEntryCommand = new InsertCounterEntryCommand();
                insertCounterEntryCommand.BuildParamsRequest(insertCounterEntry);
                insertCounterEntryCommand.AddOutputParameter("@CounterId", SqlDbType.Int);

                return Container.SqlHelper.SendCommand(insertCounterEntryCommand);
            }

            public ICommandResult UpdateCounterEntry(UpdateCounterEntry updateCounterEntry)
            {
                var UpdateCounterEntryCommand = new UpdateCounterEntryCommand();

                UpdateCounterEntryCommand.BuildParamsRequest(updateCounterEntry);

                return Container.SqlHelper.SendCommand(UpdateCounterEntryCommand);
            }

            public ICommandResult DeleteCounterEntry(DeleteCounterEntry deleteCounterEntry)
            {
                var DeleteCounterEntryCommand = new DeleteCounterEntryCommand();

                DeleteCounterEntryCommand.BuildParamsRequest(deleteCounterEntry);

                return Container.SqlHelper.SendCommand(DeleteCounterEntryCommand);
            }


            //Whiteboards
            public ICommandResult InsertWhiteboardEntry(InsertWhiteboardEntry insertWhiteboardEntry)
            {
                var insertWhiteboardEntryCommand = new InsertWhiteboardEntryCommand();
                insertWhiteboardEntryCommand.BuildParamsRequest(insertWhiteboardEntry);
                insertWhiteboardEntryCommand.AddOutputParameter("@WhiteboardId", SqlDbType.Int);

                return Container.SqlHelper.SendCommand(insertWhiteboardEntryCommand);
            }

            public ICommandResult UpdateWhiteboardEntry(UpdateWhiteboardEntry updateWhiteboardEntry)
            {
                var UpdateWhiteboardCommand = new UpdateWhiteboardEntryCommand();

                UpdateWhiteboardCommand.BuildParamsRequest(updateWhiteboardEntry);

                return Container.SqlHelper.SendCommand(UpdateWhiteboardCommand);
            }

            public ICommandResult DeleteWhiteboardEntry(DeleteWhiteboardEntry deleteWhiteboardEntry)
            {
                var DeleteWhiteboardCommand = new DeleteWhiteboardEntryCommand();

                DeleteWhiteboardCommand.BuildParamsRequest(deleteWhiteboardEntry);

                return Container.SqlHelper.SendCommand(DeleteWhiteboardCommand);
            }


            //Notepads
            public ICommandResult InsertNotepadEntry(InsertNotepadEntry insertNotepadEntry)
            {
                var insertNotepadEntryCommand = new InsertNotepadEntryCommand();
                insertNotepadEntryCommand.BuildParamsRequest(insertNotepadEntry);
                insertNotepadEntryCommand.AddOutputParameter("@NotepadId", SqlDbType.Int);

                return Container.SqlHelper.SendCommand(insertNotepadEntryCommand);
            }

            public ICommandResult UpdateNotepadEntry(UpdateNotepadEntry updateNotepadEntry)
            {
                var UpdateNotepadCommand = new UpdateNotepadEntryCommand();

                UpdateNotepadCommand.BuildParamsRequest(updateNotepadEntry);

                return Container.SqlHelper.SendCommand(UpdateNotepadCommand);
            }

            public ICommandResult DeleteNotepadEntry(DeleteNotepadEntry deleteNotepadEntry)
            {
                var DeleteNotepadCommand = new DeleteNotepadEntryCommand();

                DeleteNotepadCommand.BuildParamsRequest(deleteNotepadEntry);

                return Container.SqlHelper.SendCommand(DeleteNotepadCommand);
            }


            //Images
            public ICommandResult InsertImageEntry(InsertImageEntry insertImageEntry)
            {
                var insertImageEntryCommand = new InsertImageEntryCommand();
                insertImageEntryCommand.BuildParamsRequest(insertImageEntry);
                insertImageEntryCommand.AddOutputParameter("@ImageId", SqlDbType.Int);

                return Container.SqlHelper.SendCommand(insertImageEntryCommand);
            }

            public ICommandResult UpdateImageEntry(UpdateImageEntry updateImageEntry)
            {
                var UpdateImageEntryCommand = new UpdateImageEntryCommand();

                UpdateImageEntryCommand.BuildParamsRequest(updateImageEntry);

                return Container.SqlHelper.SendCommand(UpdateImageEntryCommand);
            }
        }

        public class DbQueries : IDbQueries
        {
            private readonly DatabaseRequestsFacade Container;

            public DbQueries(DatabaseRequestsFacade container)
            {
                Container = container;
            }

            public GetMultipleChecklistsResponseModel GetChecklistEntries()
            {

                GetAllChecklistEntriesQuery getChecklistEntriesQuery = new GetAllChecklistEntriesQuery();

                QueryResult queryResult = Container.SqlHelper.SendQuery(getChecklistEntriesQuery);

                IList<GetChecklistEntry> checklistEntryModels =
                    (IList<GetChecklistEntry>)
                        Container.QueryResultParser.ParseMultipleRecords(queryResult.Data, typeof(GetChecklistEntry));


                GetMultipleChecklistsResponseModel getChecklistEntriesResponseModel = new GetMultipleChecklistsResponseModel
                {
                    ChecklistEntries = checklistEntryModels
                };

                return getChecklistEntriesResponseModel;
            }




            public GetChecklistEntry GetChecklistEntry(int checklistEntryId)
            {
                GetChecklistEntryQuery getChecklistEntryQuery = new GetChecklistEntryQuery();

                getChecklistEntryQuery.AddParameter("ChecklistId", checklistEntryId);

                QueryResult queryResult = Container.SqlHelper.SendQuery(getChecklistEntryQuery);

                GetChecklistEntry checklistEntryModel =
                    (GetChecklistEntry)
                        Container.QueryResultParser.ParseSingleRecord(queryResult.Data,
                            typeof(GetChecklistEntry));

                return checklistEntryModel;
            }


            public GetMultipleChecklistGroupsResponseModel GetChecklistChildrenQuery(int checklistId)
            {

                GetChecklistChildrenQuery getChecklistChildrenQuery = new GetChecklistChildrenQuery();

                getChecklistChildrenQuery.AddParameter("ChecklistId", checklistId);

                QueryResult queryResult = Container.SqlHelper.SendQuery(getChecklistChildrenQuery);

                IList<GetChecklistGroupEntry> checklistGroupEntryModels =
                    (IList<GetChecklistGroupEntry>)
                        Container.QueryResultParser.ParseMultipleRecords(queryResult.Data, typeof(GetChecklistGroupEntry));


                GetMultipleChecklistGroupsResponseModel getMultipleChecklistGroupsResponseModel = new GetMultipleChecklistGroupsResponseModel
                {
                    ChecklistGroupEntries = checklistGroupEntryModels
                };

                return getMultipleChecklistGroupsResponseModel;
            }


            public GetChecklistGroupEntry GetChecklistGroupEntry(int checklistGroupEntryId)
            {
                GetChecklistGroupEntryQuery getChecklistGroupEntryQuery = new GetChecklistGroupEntryQuery();

                getChecklistGroupEntryQuery.AddParameter("ChecklistGroupId", checklistGroupEntryId);

                QueryResult queryResult = Container.SqlHelper.SendQuery(getChecklistGroupEntryQuery);

                GetChecklistGroupEntry checklistGroupEntryModel =
                    (GetChecklistGroupEntry)
                        Container.QueryResultParser.ParseSingleRecord(queryResult.Data,
                            typeof(GetChecklistGroupEntry));

                return checklistGroupEntryModel;
            }



            public GetMultipleChecklistItemsResponseModel GetChecklistGroupChildrenQuery(int checklistGroupId)
            {

                GetChecklistGroupChildrenQuery getChecklistGroupChildrenQuery = new GetChecklistGroupChildrenQuery();

                getChecklistGroupChildrenQuery.AddParameter("ChecklistGroupId", checklistGroupId);

                QueryResult queryResult = Container.SqlHelper.SendQuery(getChecklistGroupChildrenQuery);

                IList<GetChecklistItemEntry> checklistItemEntryModels =
                    (IList<GetChecklistItemEntry>)
                        Container.QueryResultParser.ParseMultipleRecords(queryResult.Data, typeof(GetChecklistItemEntry));


                GetMultipleChecklistItemsResponseModel getMultipleChecklistItemsResponseModel = new GetMultipleChecklistItemsResponseModel
                {
                    ChecklistItemEntries = checklistItemEntryModels
                };

                return getMultipleChecklistItemsResponseModel;
            }


            public GetChecklistItemEntry GetChecklistItemEntry(int checklistItemEntryId)
            {
                GetChecklistItemEntryQuery getChecklistItemEntryQuery = new GetChecklistItemEntryQuery();

                getChecklistItemEntryQuery.AddParameter("ChecklistItemId", checklistItemEntryId);

                QueryResult queryResult = Container.SqlHelper.SendQuery(getChecklistItemEntryQuery);

                GetChecklistItemEntry checklistItemEntryModel =
                    (GetChecklistItemEntry)
                        Container.QueryResultParser.ParseSingleRecord(queryResult.Data,
                            typeof(GetChecklistItemEntry));

                return checklistItemEntryModel;
            }

            public GetCounterEntry GetCounterEntry(int counterId)
            {
                GetCounterEntryQuery getCounterEntryQuery = new GetCounterEntryQuery();

                getCounterEntryQuery.AddParameter("CounterId", counterId);

                QueryResult queryResult = Container.SqlHelper.SendQuery(getCounterEntryQuery);

                GetCounterEntry counterEntryModel = (GetCounterEntry)Container.QueryResultParser.ParseSingleRecord(queryResult.Data, typeof(GetCounterEntry));

                return counterEntryModel;
            }

            public GetImageEntry GetImageEntry(int imageId)
            {
                GetImageEntryQuery getImageEntryQuery = new GetImageEntryQuery();

                getImageEntryQuery.AddParameter("ImageId", imageId);

                QueryResult queryResult = Container.SqlHelper.SendQuery(getImageEntryQuery);

                GetImageEntry imageEntryModel = (GetImageEntry)Container.QueryResultParser.ParseSingleRecord(queryResult.Data, typeof(GetImageEntry));

                return imageEntryModel;
            }

            public GetWhiteboardEntry GetWhiteboardEntry(int whiteboardId)
            {
                GetWhiteboardEntryQuery getWhiteboardEntryQuery = new GetWhiteboardEntryQuery();

                getWhiteboardEntryQuery.AddParameter("WhiteboardId", whiteboardId);

                QueryResult queryResult = Container.SqlHelper.SendQuery(getWhiteboardEntryQuery);

                GetWhiteboardEntry whiteboardEntryModel = (GetWhiteboardEntry)Container.QueryResultParser.ParseSingleRecord(queryResult.Data, typeof(GetWhiteboardEntry));

                return whiteboardEntryModel;
            }

            public GetNotepadEntry GetNotepadEntry(int notepadId)
            {
                GetNotepadEntryQuery getNotepadEntryQuery = new GetNotepadEntryQuery();

                getNotepadEntryQuery.AddParameter("NotepadId", notepadId);

                QueryResult queryResult = Container.SqlHelper.SendQuery(getNotepadEntryQuery);

                GetNotepadEntry notepadEntryModel = (GetNotepadEntry)Container.QueryResultParser.ParseSingleRecord(queryResult.Data, typeof(GetNotepadEntry));

                return notepadEntryModel;
            }
        }
    }
}
