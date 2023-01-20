namespace exe1HW.Models
{
    public class Vacation
    {
        //********** Attribute *****************

        public int Id { get; set; }
        public string UserEmail { get; set; }
        public int FlatId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime Enddate { get; set; }
        //********** End of attribute *****************

        //********** Methods *****************
        public int Insert()
        {

            //Check if the flat exist
            bool flag = false;
            List<Flat> FlatList = new List<Flat>();
            DBservices dbs = new DBservices();
            FlatList = dbs.Read();
            foreach (var item in FlatList)
            {
                if (item.Id == this.FlatId)
                    flag = true;
            }
            if (flag == false)
            {
                throw new Exception($"*!*Flat with ID: {this.Id} not exist in flats list*!*");

            }

            //End of check if the flat exist
            List<Vacation> OrderList = Read();
            foreach (Vacation item in OrderList)
            {

                //if (item.Id == this.Id)
                //{
                //    throw new Exception($"*!*Id should be unique, order ID {this.Id} already exist in the List*!*");
                //}

                if (item.FlatId == this.FlatId)
                {
                    if ((item.StartDate <= this.StartDate && item.Enddate > this.StartDate) || (item.StartDate <= this.Enddate && item.Enddate >= this.Enddate) || item.StartDate >= this.StartDate && item.Enddate <= this.Enddate)
                    {
                        throw new Exception($"*!*Cannot rent an apartment ({item.FlatId}) the selected dates are not available*!*");
                    }
                }

            }
            return dbs.Insert(this);

        }
        public static List<Vacation> Read()
        {
            DBservices dbs = new DBservices();
            return dbs.ReadVaction();

        }
        public List<Vacation> Delete(int id)
        {
            DBservices dbs = new DBservices();
            return dbs.DeleteVacation(id);
        }


        public static List<Vacation> GetBetweenDates(DateTime from, DateTime to)
        {


            List<Vacation> tmpList = new List<Vacation>();
            //foreach (Vacation item in OrderList)
            //{
            //    if (from.Date<=item.StartDate.Date && to.Date>=item.Enddate.Date)
            //    {
            //        tmpList.Add(item);
            //    }
            //}
            return tmpList;
        }
        //********** End of methods *****************
        public  List<Vacation> Update()
        {
            //End of check if the flat exist
            List<Vacation> OrderList = Read();
            foreach (Vacation item in OrderList)
            {

                //if (item.Id == this.Id)
                //{
                //    throw new Exception($"*!*Id should be unique, order ID {this.Id} already exist in the List*!*");
                //}

                if (item.FlatId == this.FlatId)
                {
                    if ((item.StartDate <= this.StartDate && item.Enddate > this.StartDate) || (item.StartDate <= this.Enddate && item.Enddate >= this.Enddate) || item.StartDate >= this.StartDate && item.Enddate <= this.Enddate)
                    {
                        if(item.UserEmail!=this.UserEmail)
                        {
                            throw new Exception($"*!*Cannot rent an apartment ({item.FlatId}) the selected dates are not available*!*");
                        }
                        
                    }
                }

            }
            DBservices dbs = new DBservices();
            return dbs.UpdateVaction(this);


        }

        public List<Object> getvagPrice(int month)
        {
            DBservices dbs = new DBservices();
            return dbs.getvagPrice(month);
        }
    }
}
