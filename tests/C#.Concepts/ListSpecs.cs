namespace C_.Concepts
{
    public class ListSpecs
    {
        private List<Person2> CreatePeople()
        {
            return new List<Person2>
            {
                new Person2(1, "Alice", 30),
                new Person2(2, "Bob", 25),
                new Person2(3, "Charlie", 35),
                new Person2(4, "David", 25)
            };
        }

        [Fact]
        public void Add_ShouldIncreaseCount()
        {
            var list = new List<Person2>();
            list.Add(new Person2(1, "Alice", 30));

            Assert.Single(list);
        }

        [Fact]
        public void AddRange_ShouldAddMultipleItems()
        {
            var list = new List<Person2>();
            var people = CreatePeople();

            list.AddRange(people);

            Assert.Equal(4, list.Count);
        }

        [Fact]
        public void Insert_ShouldInsertAtSpecificIndex()
        {
            var list = CreatePeople();
            var newPerson = new Person2(99, "Inserted", 40);

            list.Insert(1, newPerson);

            Assert.Equal(newPerson, list[1]);
        }

        [Fact]
        public void Remove_ShouldRemoveItem()
        {
            var list = CreatePeople();
            var person = list[0];

            list.Remove(person);

            Assert.DoesNotContain(person, list);
        }

        [Fact]
        public void RemoveAt_ShouldRemoveByIndex()
        {
            var list = CreatePeople();
            list.RemoveAt(0);

            Assert.Equal(3, list.Count);
            Assert.DoesNotContain(list, p => p.Id == 1);
        }

        [Fact]
        public void RemoveAll_ShouldRemoveMatchingItems()
        {
            var list = CreatePeople();

            list.RemoveAll(p => p.Age == 25);

            Assert.DoesNotContain(list, p => p.Age == 25);
            Assert.Equal(2, list.Count);
        }

        [Fact]
        public void Find_ShouldReturnFirstMatch()
        {
            var list = CreatePeople();

            var result = list.Find(p => p.Age == 25);

            Assert.Equal("Bob", result!.Name);
        }

        [Fact]
        public void Exists_ShouldReturnTrueIfMatchFound()
        {
            var list = CreatePeople();

            bool exists = list.Exists(p => p.Name == "Alice");

            Assert.True(exists);
        }

        [Fact]
        public void IndexOf_ShouldReturnCorrectIndex()
        {
            var list = CreatePeople();
            var person = list[2];

            int index = list.IndexOf(person);

            Assert.Equal(2, index);
        }

        [Fact]
        public void Contains_ShouldCheckReferenceEquality()
        {
            var list = CreatePeople();
            var person = list[0];

            Assert.True(list.Contains(person));
        }

        [Fact]
        public void Sort_ByAge_ShouldOrderAscending()
        {
            var list = CreatePeople();

            list.Sort((x, y) => x.Age.CompareTo(y.Age));

            Assert.Equal(25, list[0].Age);
            Assert.Equal(25, list[1].Age);
            Assert.Equal(30, list[2].Age);
        }

        [Fact]
        public void OrderBy_WithLinq_ShouldNotModifyOriginalList()
        {
            var list = CreatePeople();

            var ordered = list.OrderBy(p => p.Name).ToList();

            Assert.NotEqual(list[0], ordered[0]);
        }

        [Fact]
        public void ForEach_ShouldExecuteActionForEachElement()
        {
            var list = CreatePeople();
            int totalAge = 0;

            list.ForEach(p => totalAge += p.Age);

            Assert.Equal(30 + 25 + 35 + 25, totalAge);
        }

        [Fact]
        public void Clear_ShouldRemoveAllItems()
        {
            var list = CreatePeople();

            list.Clear();

            Assert.Empty(list);
        }

        [Fact]
        public void TrueForAll_ShouldValidateAllItems()
        {
            var list = CreatePeople();

            bool result = list.TrueForAll(p => p.Age > 20);

            Assert.True(result);
        }

        [Fact]
        public void ConvertAll_ShouldProjectToAnotherType()
        {
            var list = CreatePeople();

            var names = list.ConvertAll(p => p.Name);

            Assert.Contains("Alice", names);
            Assert.Equal(4, names.Count);
        }

        [Fact]
        public void CopyTo_ShouldCopyElementsToArray()
        {
            var list = CreatePeople();
            var array = new Person2[list.Count];

            list.CopyTo(array);

            Assert.Equal(list[0], array[0]);
        }

        [Fact]
        public void Update_ByIndex_ShouldReplaceElement()
        {
            var list = CreatePeople();

            var updated = new Person2(1, "Alice Updated", 31);

            list[0] = updated;

            Assert.Equal("Alice Updated", list[0].Name);
            Assert.Equal(31, list[0].Age);
        }

        [Fact]
        public void Capacity_ShouldGrowAutomatically()
        {
            var list = new List<Person2>(1);

            list.Add(new Person2(1, "A", 1));
            list.Add(new Person2(2, "B", 2));

            Assert.True(list.Capacity >= 2);
        }

        [Fact]
        public void List_IsReferenceType()
        {
            var list1 = CreatePeople();
            var list2 = list1;

            list2.Add(new Person2(99, "New", 50));

            Assert.Equal(5, list1.Count);
        }
    }

    public class Person2 : IComparable<Person2>
    {
        public int Id { get; }
        public string Name { get; }
        public int Age { get; }

        public Person2(int id, string name, int age)
        {
            Id = id;
            Name = name;
            Age = age;
        }

        public int CompareTo(Person2? other)
        {
            return Age.CompareTo(other!.Age);
        }
    }
}