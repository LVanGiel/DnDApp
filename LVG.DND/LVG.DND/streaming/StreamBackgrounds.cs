using LVG.DND.Models;
using LVG.DND.streaming.Base;
using Newtonsoft.Json;

namespace LVG.DND.streaming
{
    internal class StreamBackgrounds : BaseStream
    {
        List<Background> backgrounds = new List<Background>();
        string basepath = FileSystem.Current.AppDataDirectory;
        public StreamBackgrounds()
        {
            PushBackgrounds();
        }
        private void PushBackgrounds()
        {
            var pathBackgrounds = Path.Combine(basepath, @"Data\Backgrounds\");
            var pathString = Path.Combine(basepath, @"Data\");
            AddBackgrounds();

            System.IO.Directory.CreateDirectory(pathString);
            System.IO.Directory.CreateDirectory(pathBackgrounds);

            foreach (Background background in backgrounds)
            {
                CreateBackgroundFile(background, pathBackgrounds);
            }
            
        }
        private void CreateBackgroundFile(Background background, string basepath)
        {
            var txtName = background.Name.Replace(" ", "") + ".txt";
            var path = Path.Combine(basepath, txtName);

            CreateFileCheck(path);
            File.WriteAllText(path, JsonConvert.SerializeObject(background));
        }
        public void AddBackgrounds()
        {
            backgrounds = new List<Background>
            {
                //To Do
                new Background 
                {
                    Name = "Folk Hero",
                    Personalities = new List<PersonalityTrait>
                    {
                        new PersonalityTrait {Description = "I judge people by their actions, not their words"},
                        new PersonalityTrait {Description = "If someone is in trouble, I'm always ready to lend help"},
                        new PersonalityTrait {Description = "When I set my mind to something, I follow through no matter what gets in my way"},
                        new PersonalityTrait {Description = "I have a strong sense of fair play and always try to find the most equitable solution to arguments"},
                        new PersonalityTrait {Description = "I'm confident in my own abilities and do what I can to instill confidence in others"},
                        new PersonalityTrait {Description = "Thinking is for other people. I prefer action"},
                        new PersonalityTrait {Description = "I misuse long words in an attempt to sound smarter"},
                        new PersonalityTrait {Description = "I get bored easily. When am I going to get on with my destiny?"}
                    },
                    Ideals = new List<Ideal>
                    {
                        new Ideal{Description = "Respect. People deserve to be treated with dignity and respect. (Good)"},
                        new Ideal{Description = "Fairness. No one should get preferential treatment before the law, and no one is above the law. (Lawful)"},
                        new Ideal{Description = "Freedom. Tyrants must not be allowed to oppress the people. (Chaotic)"},
                        new Ideal{Description = "Might. If I become strong, I can take what I want – what I deserve. (Evil)"},
                        new Ideal{Description = "Sincerity. There's no good in pretending to be something I'm not. (Neutral)"},
                        new Ideal{Description = "Destiny. Nothing and no one can steer me away from my higher calling. (Any)"}
                    },
                    Bonds = new List<Bond>
                    {
                        new Bond{Description="I have a family, but I have no idea where they are. One day, I hope to see them again"},
                        new Bond{Description="I worked the land, I love the land, and I will protect the land"},
                        new Bond{Description="A proud noble once gave me a horrible beating, and I will take my revenge on any bully I encounter"},
                        new Bond{Description="My tools are symbols of my past life, and I carry them so that I will never forget my roots"},
                        new Bond{Description="I protect those who cannot protect themselves"},
                        new Bond{Description="I wish my childhood sweetheart had come with me to pursue my destiny"},
                    },
                    Flaws = new List<Flaw>
                    {
                        new Flaw{Description = "The tyrant who rules my land will stop at nothing to see me killed"},
                        new Flaw{Description = "I'm convinced of the significance of my destiny, and blind to my shortcomings and the risk of failure"},
                        new Flaw{Description = "The people who knew me when I was young know my shameful secret, so I can never go home again"},
                        new Flaw{Description = "I have a weakness for the vices of the city, especially hard drink"},
                        new Flaw{Description = "Secretly, I believe that things would be better if I were a tyrant lording over the land"},
                        new Flaw{Description = "I have trouble trusting in my allies"},
                    }
                    //tbc
                }
            };
        }
    }
}
