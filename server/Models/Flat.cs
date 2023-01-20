
namespace exe1HW.Models

{
    public class Flat
    {

        //********** Attribute *****************

 
        public int Id { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        
        double price;
        public double NumberOfRooms { get; set; }
        //********** End of attribute *****************

        //********** Properties *****************
        public double Price { get => price; set { price = Discount(value); } }
        //********** End of properties *****************
        //********** Methods *****************
        public int Insert()
        {
            DBservices dbs = new DBservices();
            return dbs.Insert(this);
        }
        public static List<Flat> Read()
        {
            DBservices dbs = new DBservices();
            return dbs.Read();
        }
        public List<Flat> Delete(int id)
        {
            try
            {
                DBservices dbs = new DBservices();
                return dbs.DeleteFlat(id);
            }
            catch (Exception ex)
            {
                return new List<Flat>();

            }
        }
        public List<Flat> Update()
        {
            DBservices dbs = new DBservices();
            return dbs.UpdateFlat(this);
        }

        public static List<Flat> getByCityPrice(string city, double maxPrice)
        {
            DBservices dbs = new DBservices();
            List<Flat> FlatsList = dbs.Read();
            foreach (Flat item in FlatsList)
            {
                if (item.City == city && item.Price < maxPrice)
                    FlatsList.Add(item);
            }
            return FlatsList;
        }




        private double Discount(double value)
        {
            if (value > 100 && this.NumberOfRooms > 1)
            {
                value = value * (float)0.9;
            }
            return value;
        }
        //********** End of methods *****************

    }
}
