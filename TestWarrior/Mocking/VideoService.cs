using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace TestWarrior.Mocking
{
    public class VideoService
    {
        //pros(for all dependency injection variants): 
        //(VideoService class becomes loosely coupled and testable)
        //in production code we can pass a real FileReader object to ReadVideoTitle method (TestWarrior.Program) 
        //whereas in test we can pass fake FileReader object (TestWarrior.UnitTests.Mocking.VideoServiceTests)
        //cons:
        //changing the signature of this method(especially if we have this method on many places)
        //some di frameworks cannot inject dependencies via method parameters
        public string ReadVideoTitle(IFileReader fileReader)
        {
            var str = fileReader.Read("video.txt");
            var video = JsonConvert.DeserializeObject<Video>(str);
            if (video == null)
                return "Error parsing the video.";
            return video.Title;
        }

        public string GetUnprocessedVideosAsCsv()
        {
            var videoIds = new List<int>();

            using (var context = new VideoContext())
            {
                var videos =
                    (from video in context.Videos
                     where !video.IsProcessed
                     select video).ToList();

                foreach (var v in videos)
                    videoIds.Add(v.Id);

                return String.Join(",", videoIds);
            }
        }
    }

    public class Video
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public bool IsProcessed { get; set; }
    }

    public class VideoContext : DbContext
    {
        public DbSet<Video> Videos { get; set; }
    }
}
