//using AutoMapper.Configuration;
//using FirebaseNet.Messaging;
//using MediHubSC.Core.Entities;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.IdentityModel.Tokens;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading;
//using System.Threading.Tasks;
//using System.Web;

//namespace MVCForum.Website.Helper
//{
//    [Produces("application/json")]
//    public class FirebaseHelper
//    {
//        private IConfiguration _config;
//        public FirebaseHelper( IConfiguration config)
//        {
//            _config = config;
//        }

//        public async static Task<List<NoticationFireBase>> PushNotification(List<Message> list)
//        {
//            var _listNtf = new List<NoticationFireBase>();

//            // Execute the task 10 times.
//            foreach (var item in list)
//            {
//                await Task.Factory.StartNew(() => SendNotifiCation(item, _listNtf),
//            CancellationToken.None,
//              TaskCreationOptions.LongRunning,
//              TaskScheduler.Default);
//            }

//            return _listNtf;
//        }
//        private static void SendNotifiCation(Message id,  List<NoticationFireBase> list)
//        {
//            try
//            {
               
//                Message item = id;
//                FCMClient client = new FCMClient("AAAA43nuP98:APA91bHWXfVh0ObqeppR8oLA--W9jHEzPBxgUcssLiD9khLD_IOZj2xJcQtsBjt4ojhklHtosvd4ekWFytPwlVRxSQOOhwUOZFJj1wQ88uRIN-cL5_Db8aimd54Sva6SSwuWR5spzEwS");
//                var result = client.SendMessageAsync(item).Result as DownstreamMessageResponse;
//                //Convert it to a UTF16 - encoded character.
//                 var not = new NoticationFireBase
//                 {
//                     CreatedDate = DateTime.Now,
//                     KeyCodeActive = item.To,
//                     Message = item.Notification.Body,
//                     Status = result.Success.ToString(),
//                     Title = item.Notification.Title,
                     
                     
//                 };
//                list.Add(not);
//            }
//            catch (Exception ex)
//            {
                
//            }

//        }

//        public async static Task<List<NoticationFireBase>> PushNotificationCmeDoctor(List<Message> list)
//        {
//            var _listNtf = new List<NoticationFireBase>();

//            // Execute the task 10 times.
//            foreach (var item in list)
//            {
//                await Task.Factory.StartNew(() => SendNotifiCationCmeDoctor(item, _listNtf),
//                    CancellationToken.None,
//                    TaskCreationOptions.LongRunning,
//                    TaskScheduler.Default);
//            }

//            return _listNtf;
//        }
//        private static void SendNotifiCationCmeDoctor(Message id, List<NoticationFireBase> list)
//        {
//            try
//            {

//                Message item = id;
//                FCMClient client = new FCMClient("AAAAzqXwFG4:APA91bHDd1ezdo7uPZtm4QfxhPSUiwK9tjp7kdesJaDe71MZj7FG5kHQksYRklFXgrGgfL3cu0SZkdQPpvC4Z6V_NRh5pJwPL37BGd_Yp5hVvc-b2JrqfBik-lMdgBGUDvgrwFt_yZlH");
//                var result = client.SendMessageAsync(item).Result as DownstreamMessageResponse;
//                //Convert it to a UTF16 - encoded character.
//                var not = new NoticationFireBase
//                {
//                    CreatedDate = DateTime.Now,
//                    KeyCodeActive = item.To,
//                    Message = item.Notification.Body,
//                    Status = result.Success.ToString(),
//                    Title = item.Notification.Title,

//                };
//                list.Add(not);
//            }
//            catch (Exception ex)
//            {

//            }

//        }

//    }
//}