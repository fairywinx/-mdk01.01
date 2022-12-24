using PracticWork9;

List<Phone> phones = new List<Phone>();


PersonCreate person = new PersonCreate();
phones.Add(person.GenerateNote("Анастасия", 4444));

IndividualCreate individual = new IndividualCreate();
phones.Add(individual.GenerateNote("Министерство образования", 5555));

InstitutionCreate institution = new InstitutionCreate();
phones.Add(institution.GenerateNote("ОКЭИ", 7777));

foreach (var item in phones)
{
    Console.WriteLine(item.GetInfo());
}