using System;
public class person { 
    public int age;
    public string name;
    public string sex;
    public string id;
    
    person(int age,string name,string sex,string id)
    {
        this.age = age;
        this.name = name;
        this.sex = sex;
        this.id = id;
    }

    public int getAge() {
        return age;
    }

    static void Main(string[] args)
      {
         person p=new person(10,"altria","男","001");
         Console.WriteLine("age=:",p.getAge());
      }
}