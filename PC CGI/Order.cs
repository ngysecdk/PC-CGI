using System;

namespace PC_CGI
{
    //TODO Добавить возможность сохранения заказа
    class Order
    {
        void Set(string TableName, string value)
        {
            switch (TableName)
            {
                case "Колки": break;
                case "Бридж": break;
                case "Звукосниматель": break;
                case "Анкер": break;
                case "Вид_сборки": break;
                case "Материал_корпуса": break;
                case "Струны": break;
                case "Покраска": break;
                case "Материал_грифа": break;
                case "Электронная_начинка": break;
                default: throw new Exception("Разработчик дурачок, ошибся");
            }
        }
        public string FIO = "";
        public string Phone = "";
        public string Description = "";
        public string ColoringImageLinck = "";
        public string Model3DLink = "";
        public string Kolk = "1";
        public string SoundGet = "1";
        public string Bridge = "1";
        public string Anker = "1";
        public string TypeBuild = "1";
        public string TypeGrif = "1";
        public string DecaMaterial = "1";
        public string Strings = "1";
        public string Colouring = "1";
        public string Electric = "1";
    }
}
