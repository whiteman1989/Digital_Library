using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Digital_Library.DAL.Entities;

namespace Digital_Library.DAL.Data
{
    public class ApplicationDbInitializer : DropCreateDatabaseAlways<ApplicationContext>
    {
        protected override void Seed(ApplicationContext context)
        {
            List<Post> posts = new List<Post>
            {
                new Post 
                {
                    Title = "What is Lorem Ipsum?",
                    Text = "Lorem Ipsum is simply dummy text of the printing and " +
                    "typesetting industry. Lorem Ipsum has been the industry's standard dummy text " +
                    "ever since the 1500s, when an unknown printer took a galley of type and scrambled " +
                    "it to make a type specimen book. It has survived not only five centuries, but " +
                    "also the leap into electronic typesetting, remaining essentially unchanged. " +
                    "It was popularised in the 1960s with the release of Letraset sheets containing " +
                    "Lorem Ipsum passages, and more recently with desktop publishing software like " +
                    "Aldus PageMaker including versions of Lorem Ipsum.",
                    Date = new DateTime(2021,04,01)
                },
                new Post
                {
                    Title = "Why do we use it?",
                    Text = "It is a long established fact that a reader will be distracted " +
                    "by the readable content of a page when looking at its layout. The point of using " +
                    "Lorem Ipsum is that it has a more-or-less normal distribution of letters, as opposed " +
                    "to using 'Content here, content here', making it look like readable English. Many " +
                    "desktop publishing packages and web page editors now use Lorem Ipsum as their default " +
                    "model text, and a search for 'lorem ipsum' will uncover many web sites still in their " +
                    "infancy. Various versions have evolved over the years, sometimes by accident, sometimes " +
                    "on purpose (injected humour and the like).",
                    Date = new DateTime(2021,04, 05)
                },
                new Post
                {
                    Title = "Where does it come from?",
                    Text = "Contrary to popular belief, Lorem Ipsum is not simply " +
                    "random text. It has roots in a piece of classical Latin literature from 45 BC, making " +
                    "it over 2000 years old. Richard McClintock, a Latin professor at Hampden-Sydney College " +
                    "in Virginia, looked up one of the more obscure Latin words, consectetur, from a Lorem " +
                    "Ipsum passage, and going through the cites of the word in classical literature, " +
                    "discovered the undoubtable source. Lorem Ipsum comes from sections 1.10.32 and 1.10.33 " +
                    "of \"de Finibus Bonorum et Malorum\" (The Extremes of Good and Evil) by Cicero, written " +
                    "in 45 BC. This book is a treatise on the theory of ethics, very popular during the " +
                    "Renaissance. The first line of Lorem Ipsum, \"Lorem ipsum dolor sit amet..\", comes " +
                    "from a line in section 1.10.32.",
                    Date = new DateTime(2021, 04, 16)
                }
            };

            List<Comment> comments = new List<Comment>
            {
                new Comment
                {
                    Author = "Oleg",
                    Text = "I am ready to meet my Maker. Whether my Maker is prepared for the " +
                    "great ordeal of meeting me is another matter.",
                    Date = new DateTime(2021, 04, 02)
                },
                new Comment
                {
                    Author = "Ihor",
                    Text = "Microsoft bought Skype for 8,5 billion!.. what a bunch of idiots! I " +
                    "downloaded it for free!",
                    Date = new DateTime(2021, 04, 15)
                },
                new Comment
                {
                    Author = "User 1",
                    Text = "Don't steal, don't lie, don't cheat, don't sell drugs. The " +
                    "government hates competition!",
                    Date = new DateTime(2021,04,16)
                },
                new Comment
                {
                    Author = "Max",
                    Text = "Some people come into our lives and leave footprints on our hearts, " +
                    "while others come into our lives and make us wanna leave footprints on their " +
                    "face.",
                    Date = new DateTime(2021,04,16)
                },
                new Comment
                {
                    Author = "Olga",
                    Text = "Some people come into our lives and leave footprints on our hearts, " +
                    "while others come into our lives and make us wanna leave footprints on their face.",
                    Date = new DateTime(2021,04,17)
                }
            };

            context.Posts.AddRange(posts);
            context.Comments.AddRange(comments);
            context.SaveChanges();
        }
    }
}
