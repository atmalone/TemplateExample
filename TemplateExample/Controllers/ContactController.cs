﻿using BayviewHouse.Models;
using System;
using System.Data;
using System.Web.Mvc;

namespace BayviewHouse.Controllers
{
    public class ContactController : Controller
    {
        // GET: Contact
       
        static DataSet ds;
        static DataTable dt;
        static DateTime td;
        

        // GET: ContactUs
        public ActionResult Index()
        {
            if (System.IO.File.Exists(Server.MapPath(@"~/feedback.xml")))
            {
                td = DateTime.Now;
                ds = new DataSet();

                ds.ReadXml(Server.MapPath(@"~/feedback.xml"));

                dt = ds.Tables["user_comment"];

            }
            else
            {
                ds = new DataSet("user_comments");
                dt = new DataTable("user_comment");
                dt.Columns.Add("name");
                dt.Columns.Add("email");
                dt.Columns.Add("bookingRef");
                dt.Columns.Add("topic");
                dt.Columns.Add("comments");
                dt.Columns.Add("stay_again");
                dt.Columns.Add("recommend");
                dt.Columns.Add("date");
                ds.Tables.Add(dt);

            }

            return View();
        }

        public ActionResult Contact (ContactModel model)
        {
            if (ModelState.IsValid)
            {
                DataRow row = dt.NewRow();
                if (model.Name == "" || model.Name == null)
                    row["name"] = "";
                else
                    row["name"] = model.Name;
                    row["email"] = model.Email;
                    row["bookingRef"] = model.BookingRef;
                    row["topic"] = model.Topic;
                    row["comments"] = model.Comments;
                    row["stay"] = model.Stay;
                    row["recommend"] = model.Recommend;
                    row["Date"] = model.Time;
                

                dt.Rows.Add(row);
                ds.WriteXml(Server.MapPath(@"~/feedback.xml"));

                return View("Comments");
            }
            else return View("Index", model);
        }
    }
}