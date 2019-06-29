using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace TestWarrior.Mocking
{
    public class VideoService
    {
        //Refactoring Towards a Loosely-coupled Design:
        //1. move all the code that touches an external resource in separate class (in this case FileReader)
        //and isolate it from the rest of the code 
        //2. extract an interface from the FileReader class (IFileReader)
        //3. create another implementation of this interface (FakeFileReader)
        public string ReadVideoTitle()
        {
            var str = new FileReader().Read("video.txt");
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
