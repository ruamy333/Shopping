using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Shopping_Mall.Database;

namespace Shopping_Mall.View
{
    public class Discount
    {
        private DBFunction db = new DBFunction("discount");
        private String[][] disArr;
        private String[] splitArr;

        public String[] findingType (int discountID, int num, int productPrice)
        {
            String[] returnArr = new String[2];
            
            disArr = db.searchByRow("discountID", discountID.ToString());
            splitArr = disArr[0][2].Split(',');
            if (disArr[0][1].Equals("買____送____"))
            {
                returnArr[0] = "買 " + splitArr[0] + " 送 " + splitArr[1];
                returnArr[1] = type1(num, productPrice).ToString();
                return returnArr;
            } 
            else if (disArr[0][1].Equals("____ % off"))
            {
                returnArr[0] = splitArr[0] + " % off";
                returnArr[1] = type2(num, productPrice).ToString();
                return returnArr;
            }
            return returnArr;
        }
        //買____送____
        private int type1(int num, int price)
        {
            num -= num / (int.Parse(splitArr[0]) + int.Parse(splitArr[1]));
            int total = num * price;
            return total;
        }
        //____ % off
        private int type2(int num, int price)
        {
            int total = (int)(num * (price*((100-int.Parse(splitArr[0]))*0.01)));
            return total;
        }

    }
}