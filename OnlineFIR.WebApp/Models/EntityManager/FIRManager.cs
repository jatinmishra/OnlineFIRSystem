using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OnlineFIR.WebApp.Models.DB;
using OnlineFIR.WebApp.Models.ViewModel;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;
using System.Net;
using System.IO;

using System.Text;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.xml;
using iTextSharp.text.html.simpleparser;

namespace OnlineFIR.WebApp.Models.EntityManager
{
    public class FIRManager
    {
        string ch;
        public string AddFir(AddFIRView addFIRView, string filePath, string stationId)
        {
            try
            {
                using (OnlineFIRDBEntities firdb = new OnlineFIRDBEntities())
                {
                    fir_tbl fir_Tbl = new fir_tbl();
                    fir_Tbl.station_id = stationId;
                    fir_Tbl.fir_complaintnee_name = addFIRView.fir_complaintnee_name;
                    fir_Tbl.fir_complaintnee_mob_no = addFIRView.fir_complaintnee_mob_no;
                    fir_Tbl.fir_date = DateTime.Now.ToString();
                    fir_Tbl.fir_id = addFIRView.fir_complaintnee_name.Substring(0, 3) + DateTime.Now.Second.ToString();
                    fir_Tbl.fir_status = 0.ToString();
                    fir_Tbl.fir_subject = addFIRView.fir_subject;
                    fir_Tbl.aadhar_num = addFIRView.aadhar_num;
                    fir_Tbl.email = addFIRView.email;
                    fir_Tbl.fir_file_path = filePath;

                    firdb.fir_tbls.Add(fir_Tbl);
                    firdb.SaveChanges();
                    return fir_Tbl.fir_id;
                }
            }
            catch (Exception e)
            {

                return null;
            }
        }

        public string CheckStatus(string firId)
        {
            using (OnlineFIRDBEntities firdb = new OnlineFIRDBEntities())
            {
                var res = firdb.fir_tbls.Where(o => o.fir_id.Equals(firId));
                if (res.Any()) { return res.FirstOrDefault().fir_status; }
            }
            return "";
        }

        public List<string> getStationList()
        {
            using (OnlineFIRDBEntities firdb = new OnlineFIRDBEntities())
            {
                List<string> stationlist = firdb.police_station_tbls.Select(u => u.station_id).ToList();
                if (stationlist != null)
                {
                    return stationlist;
                }
                else
                    return null;
            }

        }

        public char checkUserRole(string uId, string pwd)
        {
            using (OnlineFIRDBEntities firdb = new OnlineFIRDBEntities())
            {
                var res = firdb.user_tbls.Where(o => o.user_id.Equals(uId) && o.user_password.Equals(pwd));
                if (res.Any())
                {
                    if (res.FirstOrDefault().user_role.Equals("0"))
                    { return '0'; }
                    else if (res.FirstOrDefault().user_role.Equals("1"))
                    { return '1'; }
                    else
                        return ' ';
                }
                else
                    return ' ';
            }

        }

        public List<getFIRDetails_Result> getFIRResults(string stationId)
        {
            using (OnlineFIRDBEntities firdb = new OnlineFIRDBEntities())
            {
                //List<fir_tbl> list = firdb.fir_tbls.Where(o => o.station_id.Equals(stationId)).ToList();
                return firdb.getFIRDetails(stationId).ToList();
                //return list;
                //return list;
            }
        }
        public List<getFIRDetails_Result> getFIRResultsFromStatus(string status)
        {
            using (OnlineFIRDBEntities firdb = new OnlineFIRDBEntities())
            {
                //List<fir_tbl> list = firdb.fir_tbls.Where(o => o.fir_status.Equals(status)).ToList();
                if (status.Equals("Pending"))
                {
                    return firdb.getFIRDetailsFromStatus("0").ToList();
                }
                else if (status.Equals("Done"))
                {
                    return firdb.getFIRDetailsFromStatus("1").ToList();
                }
                else return null;
                //return list;
                //return list;
            }
        }
        public string getStationIdFromUserId(string userId)
        {
            using (OnlineFIRDBEntities firdb = new OnlineFIRDBEntities())
            {
                if (userId != null)
                {
                    return firdb.police_station_tbls.Where(o => o.user_id.Equals(userId)).FirstOrDefault().station_id;
                }
                else return null;
            }
        }

        public string getEmailIdFromUserId(string userId)
        {
            using (OnlineFIRDBEntities firdb = new OnlineFIRDBEntities())
            {
                if (userId != null)
                {
                    return firdb.user_tbls.Where(o => o.user_id.Equals(userId)).FirstOrDefault().user_email;
                }
                else return null;
            }
        }

        public List<getSingleFIR_Result> getSingleFIR(string firID)
        {
            using (OnlineFIRDBEntities firdb = new OnlineFIRDBEntities())
            {
                if (firID != null) {
                    return firdb.getSingleFIR(firID).ToList(); }
                else return null;
            }
        }

        public List<EditPoliceStation> getStationDetails(string sID)
        {
            using (OnlineFIRDBEntities firdb = new OnlineFIRDBEntities())
            {
                if (sID != null) { return firdb.getStationDetails(sID).ToList(); }
                else return null;
            }
        }
        public bool checkValidFIRID(string id)
        {
            using (OnlineFIRDBEntities firdb = new OnlineFIRDBEntities())
            {
                var res = firdb.fir_tbls.Where(o => o.fir_id.Equals(id));
                if (res.Any()) { return true; }
                else return false;
            }
        }


        //public void sendSMS()
        //{
        //    // Your Account SID from twilio.com/console
        //    var accountSid = "AC691ae094b5a972d6c1dac852e3a10781";
        //    // Your Auth Token from twilio.com/console
        //    var authToken = "dec5299c3ef93e6515281e646ee0fcf0";

        //    TwilioClient.Init(accountSid, authToken);

        //    var message = MessageResource.Create(
        //        to: new PhoneNumber("+917505872209"),
        //        from: new PhoneNumber("+919695053976"),
        //        body: "Hello from C#");
        //}
        //public void sendSMS1()
        //{
        //    //Your authentication key
        //    string authKey = "195115A5rOxZT51ptB5a69c1ff";
        //    //Multiple mobiles numbers separated by comma
        //    string mobileNumber = "+919695053976";
        //    //Sender ID,While using route4 sender id should be 6 characters long.
        //    string senderId = "001081";
        //    //Your message to send, Add URL encoding here.
        //    string message = HttpUtility.UrlEncode("Test message");

        //    //Prepare you post parameters
        //    StringBuilder sbPostData = new StringBuilder();
        //    sbPostData.AppendFormat("authkey={0}", authKey);
        //    sbPostData.AppendFormat("&mobiles={0}", mobileNumber);
        //    sbPostData.AppendFormat("&message={0}", message);
        //    sbPostData.AppendFormat("&sender={0}", senderId);
        //    sbPostData.AppendFormat("&route={0}", "default");

        //    try
        //    {
        //        //Call Send SMS API
        //        string sendSMSUri = "http://api.msg91.com/api/sendhttp.php";
        //        //Create HTTPWebrequest
        //        HttpWebRequest httpWReq = (HttpWebRequest)WebRequest.Create(sendSMSUri);
        //        //Prepare and Add URL Encoded data
        //        UTF8Encoding encoding = new UTF8Encoding();
        //        byte[] data = encoding.GetBytes(sbPostData.ToString());
        //        //Specify post method
        //        httpWReq.Method = "POST";
        //        httpWReq.ContentType = "application/x-www-form-urlencoded";
        //        httpWReq.ContentLength = data.Length;
        //        using (Stream stream = httpWReq.GetRequestStream())
        //        {
        //            stream.Write(data, 0, data.Length);
        //        }
        //        //Get the response
        //        HttpWebResponse response = (HttpWebResponse)httpWReq.GetResponse();
        //        StreamReader reader = new StreamReader(response.GetResponseStream());
        //        string responseString = reader.ReadToEnd();

        //        //Close the response
        //        reader.Close();
        //        response.Close();
        //    }
        //    catch (SystemException ex)
        //    {

        //    }
        //}

        public bool createStation(AddPoliceStation addPoliceStation)
        {
            try
            {
                using (OnlineFIRDBEntities firdb = new OnlineFIRDBEntities())
                {
                    police_station_tbl police_tbl = new police_station_tbl();
                    police_tbl.station_id = addPoliceStation.station_id;
                    police_tbl.station_name = addPoliceStation.station_name;
                    police_tbl.station_incharge = addPoliceStation.station_incharge;
                    police_tbl.station_contact_no = addPoliceStation.station_contact_no;
                    police_tbl.station_address = addPoliceStation.station_address;
                    police_tbl.user_id = addPoliceStation.user_id;
                    firdb.police_station_tbls.Add(police_tbl);
                    firdb.SaveChanges();
                    return true;
                }
            }
            catch (Exception e)
            { return false; }
        }

        public bool editStation(EditPoliceStation editPoliceStation)
        {
            try
            {
                using (OnlineFIRDBEntities firdb = new OnlineFIRDBEntities())
                {
                    police_station_tbl oldTable = (from c in firdb.police_station_tbls
                                                   where c.station_id == editPoliceStation.station_id
                                                   select c).FirstOrDefault();

                    oldTable.station_id = editPoliceStation.station_id;
                    oldTable.station_name = editPoliceStation.station_name;
                    oldTable.station_incharge = editPoliceStation.station_incharge;
                    oldTable.station_contact_no = editPoliceStation.station_contact_no;
                    oldTable.station_address = editPoliceStation.station_address;
                   oldTable.user_id = editPoliceStation.user_id;
                    //firdb.police_station_tbls.Add(oldTable);
                    firdb.SaveChanges();
                    return true;
                }
            }
            catch (Exception e)
            {
                return false;

            }
        }
        public bool deleteStation(string stationId)
        {
            try
            {
                using (OnlineFIRDBEntities firdb = new OnlineFIRDBEntities())
                {
                    police_station_tbl oldTable = (from c in firdb.police_station_tbls
                                                   where c.station_id == stationId
                                                   select c).FirstOrDefault();
                    firdb.police_station_tbls.Remove(oldTable);
                    firdb.SaveChanges();
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool checkValidCredentials(string uID, string pass)
        {
            using (OnlineFIRDBEntities firdb = new OnlineFIRDBEntities())
            {
                int tbl = (from c in firdb.user_tbls where c.user_id == uID && c.user_password == pass select c).Count();
                if (tbl > 0) { return true; }
                return false;
            }
        }

        public bool resetPassword(string uID, string oldPass, string newPass)
        {
            if (uID != null && oldPass != null && newPass != null)
            {
                if (checkValidCredentials(uID, oldPass))
                {
                    try
                    {
                        using (OnlineFIRDBEntities firdb = new OnlineFIRDBEntities())
                        {

                            user_tbl tbl = (from c in firdb.user_tbls where c.user_id == uID && c.user_password == oldPass select c).FirstOrDefault();
                            tbl.user_password = newPass;
                            firdb.SaveChanges();
                            return true;
                        }
                    }
                    catch (Exception e)
                    {

                        return false;
                    }
                }
                else
                    return false;
            }
            else
                return false;
        }

        public void updateFIRStatus(string id, string status)
        {
            status = status.ToLower();
           
            if (status.Equals("pending"))  ch = "0";
            if (status.Equals("done")) ch = "1";
            using (OnlineFIRDBEntities firdb = new OnlineFIRDBEntities())
            {
                fir_tbl tbl = (from t in firdb.fir_tbls where t.fir_id == id select t).FirstOrDefault();
                tbl.fir_status = ch;
                firdb.SaveChanges();
            }
        }

        
    }
}