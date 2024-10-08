namespace dblaba.Database.Tables {
    public class TableCompetition : Table {
        public override string Name { 
            get => "competition";
        }

        public readonly string ColId = "id";
        public readonly string ColName = "name";
        public readonly string ColDate = "date_of";
        public readonly string ColTypeId = "type_id";
        public readonly string ColPlace = "place";
        public readonly string TableCompetitionTypeName;
        public readonly string TableCompetitionTypeColId;

        public override void Create(bool forced) {
            var proccesResult = ProcessDrop(forced);

            if (proccesResult == ProcessResult.Break) {
                return;
            }

            {
                var query = string.Format(@"
                    CREATE TABLE {0}
                    (
                        {1} SERIAL PRIMARY KEY,
                        {2} VARCHAR(100) UNIQUE,
                        {3} DATE,
                        {4} INTEGER,
                        {5} VARCHAR(100),
                        FOREIGN KEY ({4}) REFERENCES {6} ({7})
                    );
                ", Name, ColId, ColName, ColDate, ColTypeId, ColPlace, TableCompetitionTypeName, TableCompetitionTypeColId);

                Client.ExecuteQuite(query);
            }

            {
                var query = string.Format(@"
                    INSERT INTO {0} ({2}, {3}, {4}, {5})
                    VALUES
                        ('Футбол фан', '22-11-2025', 1, 'Москва'),
                        ('Футбол про', '23-11-2025', 1, 'Москва'),
                        ('Гандбол фан', '12-11-2025', 2, 'Париж'),
                        ('Гандбол про', '13-11-2025', 2, 'Париж'),
                        ('Гольф фан', '15-11-2025', 3, 'Лондон'),
                        ('Гольф про', '16-11-2025', 3, 'Лондон')
                    ;
                ", Name, ColId, ColName, ColDate, ColTypeId, ColPlace);

                Client.ExecuteQuite(query);
            }
        }

        public TableCompetition (TableCompetitionType tableCompetitionType) {
            TableCompetitionTypeName = tableCompetitionType.Name;
            TableCompetitionTypeColId = tableCompetitionType.ColId;
        }
    }
}
