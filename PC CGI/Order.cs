using System;
namespace PC_CGI
{
    //TODO Добавить возможность сохранения заказа
    class Order
    {
        public void Set(string TableName, string value)
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
        public string Kolk = "";
        public string SoundGet = "";
        public string Bridge = "";
        public string Anker = "";
        public string TypeBuild = "";
        public string TypeGrif = "";
        public string DecaMaterial = "";
        public string Strings = "";
        public string Colouring = "";
        public string Electric = "";
    }
}
