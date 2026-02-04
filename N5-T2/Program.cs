string application =
"{ApplicationDate} {ApplicationNumber} {OrganizationName} rektori " +
"{Rektor} ga Abituriyent {StudentName} dan Tel.: {StudentNumber} " +
"ARIZA Men joriy yilda {OrganizationName} ning {Code} - {EduSpeciality} ta'lim yo'nalishini " +
"{EduForm} ta'lim shakli, {EduLanguage} ta'lim tili bo'yicha {OrderId}-OTM sifatida tanlab, " +
"davlat test sinovida ishtirok etdim. Davlat test markazi tomonidan e'lon qilingan test natijasiga ko'ra " +
"{Ball} ball to'pladim va to'lov-kontrakt asosidagi qabul chegarasiga " +
"{DifferenceBall} ball yetmay qoldi. Shu munosabat bilan, meni qo'shimcha tarzda " +
"{EduContractSumType} tabaqalashtirilgan to'lov-kontrakt asosida talabalikka qabul qilishingizni " +
"hamda menga to'lov shartnomasini taqdim etishingizni so'rayman. " +
"Men OTM ichki tartib-qoidalari va kontrakt shartlari bilan tanishdim. " +
"Abituriyent: {Abiturient} ID raqami: {AbiturientId}";

var date = DateTime.Now;

var changedInfo = application
    .Replace("{ApplicationDate}", date.ToShortDateString())
    .Replace("{ApplicationNumber}", Guid.NewGuid().ToString())
    .Replace("{OrganizationName}", "TUIT")
    .Replace("{Rektor}", "Temurbek Adhamov")
    .Replace("{StudentName}", "Jasurbek Abdulxaev")
    .Replace("{StudentNumber}", "+998 90 917 99 98")
    .Replace("{Code}", "N10")
    .Replace("{EduSpeciality}", "Dasturiy injiniring")
    .Replace("{EduForm}", "kunduzgi")
    .Replace("{EduLanguage}", "o'zbek")
    .Replace("{OrderId}", "1")
    .Replace("{Ball}", "158.7")
    .Replace("{DifferenceBall}", "3.3")
    .Replace("{EduContractSumType}", "super-kontrakt")
    .Replace("{Abiturient}", "Abdulxaev Jasurbek")
    .Replace("{AbiturientId}", "AB123456");

Console.WriteLine(changedInfo);
