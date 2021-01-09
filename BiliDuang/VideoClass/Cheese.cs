using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiliDuang.VideoClass
{
    class Cheese
    {
        public string name = "";
        public List<episode> episodes = new List<episode>();
        public Cheese(JSONCallback.Cheese.Root root)
        {
            name = root.data.title;
            foreach (JSONCallback.Cheese.EpisodesItem epjs in root.data.episodes)
            {
                episode ep = new episode();
                ep.aid = epjs.aid;
                ep.cid = epjs.cid;
                ep.name = epjs.title;
                ep.pic = root.data.cover;
                ep.ischeese = epjs.id;
                episodes.Add(ep);
            }
            
        }
    }
}
