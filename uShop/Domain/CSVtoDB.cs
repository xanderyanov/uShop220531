using MmxCMS;
using MongoDB.Driver;

namespace uShop.Domain
{
    public class CSVtoDB
    {
        public async Task ExportCSVAsync() {

            string connectionString = "mongodb://master:159753@localhost/ushopbase?authSource=admin";
            string databaseName = "ushopbase";
            string CollectionName = "products";

            var client = new MongoClient(connectionString);
            var db = client.GetDatabase(databaseName);
            var collection = db.GetCollection<Product>(CollectionName);


            string[] lines = System.IO.File.ReadAllLines(@"D:\tovar.csv", System.Text.Encoding.UTF8);
            CSVFile csv = new(lines, ';', '"',
                "Код;Наименование;Иерархия;Артикул;Количество;Цена;Бренд;ИмяФайлаИзображения;Новинка;HAPPY_МОЛЛОстаток;ГлобусОстаток;ЛазурныйОстаток;ОранжевыйОстаток;ПассажОстаток;ТауОстаток;10 летняя батарея;Bluetooth;Барометр\\альтиметр;Браслет;Будильник;Включение,отключение звука кнопок;Водозащита;Грязеустойчивость;Дополнительно;Индикатор приливов и отливов;Индикатор уровня заряда аккумулятора;Компас;Материал корпуса;Мелодия;Мировое время;Отображение данных о Луне;Пол;Прием радиосигнала точного времени;Размер корпуса;Резерв хода;Сверх яркая подсветка;Связь со смартфоном;Скидка;Солнечная батарея;Стекло;Страна бренда;Страна производитель;Таймер;Таймер рыбалки;Термометр;Тип механизма;Ударопрочность;Устойчивость к воздействию магнитного поля;Форма корпуса;Функция поиска телефона;Функция секундомера;Хит продаж;Ход стрелки;Хронограф;Циферблат;Шагомер;ЦенаСоСкидкой",
                "Code1C;Name;Path;Article;TotalCount;Price;BrandName;ImgFileName;New;HM_Balance;GL_Balance;LZ_Balance;OR_Balance;PZ_Balance;TA_Balance;Battery10;Bluetooth;Barometer;Wristlet;Alarm;ButtonsSoundToggler;WaterProtection;DirtResistance;Extra;TideIndicator;BatteryLevelIndicator;Compass;CaseMaterial;Melody;WorldTime;MoonData;Gender;ExactTimeRadioSignal;CaseSize;PowerReserve;ExtraBrightBacklight;SmartphoneConnection;Discount;SolarBattery;Glass;BrandCountry;ProducingCountry;Taimer;FishingTimer;Thermometer;MechanismType;ImpactResistance;MagneticFieldResistance;CaseForm;PhoneSearchFunction;Stopwatch;SaleLeader;ClockhandMovement;Chronograph;ClockFace;Pedometer;DiscountPrice");
            csv.Rewind();

            List<Product> Tovars = new();


            while (csv.Next())
            {
                var tovar = new Product { Code1C = csv["Code1C"].ToString(), Name = csv["Name"], Path = csv["Path"], Article = csv["Article"], TotalCount = csv["TotalCount"], Price = csv["Price"], BrandName = csv["BrandName"], ImgFileName = csv["ImgFileName"], New = csv["New"], HM_Balance = csv["HM_Balance"], GL_Balance = csv["GL_Balance"], LZ_Balance = csv["LZ_Balance"], OR_Balance = csv["OR_Balance"], PZ_Balance = csv["PZ_Balance"], TA_Balance = csv["TA_Balance"], Battery10 = csv["Battery10"], Bluetooth = csv["Bluetooth"], Barometer = csv["Barometer"], Wristlet = csv["Wristlet"], Alarm = csv["Alarm"], ButtonsSoundToggler = csv["ButtonsSoundToggler"], WaterProtection = csv["WaterProtection"], DirtResistance = csv["DirtResistance"], Extra = csv["Extra"], TideIndicator = csv["TideIndicator"], BatteryLevelIndicator = csv["BatteryLevelIndicator"], Compass = csv["Compass"], CaseMaterial = csv["CaseMaterial"], Melody = csv["Melody"], WorldTime = csv["WorldTime"], MoonData = csv["MoonData"], Gender = csv["Gender"], ExactTimeRadioSignal = csv["ExactTimeRadioSignal"], CaseSize = csv["CaseSize"], PowerReserve = csv["PowerReserve"], ExtraBrightBacklight = csv["ExtraBrightBacklight"], SmartphoneConnection = csv["CasSmartphoneConnectioneSize"], Discount = csv["Discount"], SolarBattery = csv["SolarBattery"], Glass = csv["Glass"], BrandCountry = csv["BrandCountry"], ProducingCountry = csv["ProducingCountry"], Taimer = csv["Taimer"], FishingTimer = csv["FishingTimer"], Thermometer = csv["Thermometer"], MechanismType = csv["MechanismType"], ImpactResistance = csv["ImpactResistance"], MagneticFieldResistance = csv["MagneticFieldResistance"], CaseForm = csv["CaseForm"], PhoneSearchFunction = csv["PhoneSearchFunction"], Stopwatch = csv["Stopwatch"], SaleLeader = csv["SaleLeader"], ClockhandMovement = csv["ClockhandMovement"], Chronograph = csv["Chronograph"], ClockFace = csv["ClockFace"], Pedometer = csv["Pedometer"], DiscountPrice = csv["DiscountPrice"] };

                Console.WriteLine($"Код1C: {csv["Code1C"]}, Наименование: {csv["Name"]}, Артикул: {csv["Article"]}, Цена: {csv["Price"]}");

                Tovars.Add(tovar);

                //await collection.InsertOneAsync(tovar);

            }

            await collection.InsertManyAsync(Tovars);
        }

    }
        
}
