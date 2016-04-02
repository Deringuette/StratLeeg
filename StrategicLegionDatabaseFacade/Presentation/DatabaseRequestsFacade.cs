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
        }
    }
}
