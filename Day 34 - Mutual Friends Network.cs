namespace ConsoleApp14._2
{
    class Person
    {
        public string Name { get; set; }

        //1
        //public void AddFriend(Person friend)
        //{
        //    if (!Friends.Contains(friend))
        //    {
        //        Friends.Add(friend);
        //        friend.Friends.Add(this);
        //    }
        //}
        public List<Person> Friends = new List<Person>();
        public Person(string name) => Name = name;
    }

    class Network
    {
        private List<Person> _members = new List<Person>();
        public void AddMember(Person member)
        {
            _members.Add(member);
        }
        
        //2
        public void AddFriend(Person friend1, Person friend2)
        {
            if (!(_members.Contains(friend1) && _members.Contains(friend2)))
            {
                Console.WriteLine($"Friend not on social platform.");
            }
            else
            {
                if (!friend1.Friends.Contains(friend2))
                {
                    friend1.Friends.Add(friend2);
                    friend2.Friends.Add(friend1);
                }

            }
        }
        public void ShowNetwork()
        {
            foreach (Person member in _members)
            {
                Console.Write(member.Name + " - > ");
                List<string> friends = new List<string>();
                foreach (var friend in member.Friends)
                {
                    friends.Add(friend.Name);
                }
                Console.WriteLine(string.Join(", ", friends));
            }
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Network network = new Network();

            Person aman = new Person("Aman");
            Person bhaskar = new Person("Bhaskar");
            Person chetan = new Person("Chetan");
            Person divakar = new Person("Divakar");
            Person eena = new Person("Eena");
            network.AddMember(aman);
            network.AddMember(bhaskar);
            network.AddMember(chetan);
            network.AddMember(divakar);

            //1
            //aman.AddFriend(bhaskar);
            //aman.AddFriend(chetan);
            //bhaskar.AddFriend(chetan);
            //divakar.AddFriend(chetan);

            //2
            network.AddFriend(aman, bhaskar);
            network.AddFriend(aman, chetan);
            network.AddFriend(bhaskar, chetan);
            network.AddFriend(divakar, chetan);
            network.AddFriend(divakar, eena);

            network.ShowNetwork();
        }
    }
}
