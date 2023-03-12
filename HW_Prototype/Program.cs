// See https://aka.ms/new-console-template for more information
using HW_Prototype;

Balcony bl = new Balcony();
bl.Square = 7;
bl.Material = "Metal";
bl.RepairBl = new Repair(TypeRepair.evro);
House dom = new House(true, 5, 250, 30, 450000, TypeRepair.cosmetic, TypeHouse.townhouse, bl);
Garage gr = new Garage(true, false, 2, 15, 10000, TypeRepair.old);

Console.WriteLine(bl.GetInfo());
Console.WriteLine(dom.GetInfo());
Console.WriteLine(gr.GetInfo());

//By IMyCloneable<T>
var copyBalcony = bl.Copy();
var copyHouse = dom.Copy();
var copyGarage = gr.Copy();

Console.WriteLine("Это копия Балкона - " + copyBalcony.GetInfo());
Console.WriteLine("Это копия Дома - " + copyHouse.GetInfo());
Console.WriteLine("Это копия Гаража - " + copyGarage.GetInfo());

//By ICloneable
Balcony cloneBalcony = (Balcony)bl.Clone();
House cloneHouse = (House)dom.Clone();
Garage cloneGarage = (Garage)gr.Clone();

Console.WriteLine("Это клон Балкона - " + copyBalcony.GetInfo());
Console.WriteLine("Это клон Дома - " + copyHouse.GetInfo());
Console.WriteLine("Это клон Гаража - " + copyGarage.GetInfo());

