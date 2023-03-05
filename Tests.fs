module Tests

open System
open Xunit
open Xunit.Abstractions

type Tests(outputs: ITestOutputHelper) =

    [<Fact>]
    let ``Empty List`` () = 
        let emptyList = []
        Assert.True(List.isEmpty emptyList)

    [<Fact>]
    let``Another Empty List`` () = 
        let emptyList = List.empty<int>
        Assert.True(List.isEmpty emptyList)

    [<Fact>]
    let ``Create A Simple List`` () =
        let shoes = ["New Balance" ; "Nike"; "Puma"]
        Assert.True(List.isEmpty shoes |> not)

    [<Fact>]
    let ``Other Ways to Create a Simple List`` () = 
        let shoes = [
                                    "New Balance"
                                    "Nike"
                                    "Puma"
                                ]
        Assert.True(List.isEmpty shoes |> not)

    [<Fact>]
    let ``Other Ways to Create a Simple List Using Range Operator`` () = 
        let number10to50 = [10..50]
        Assert.True(number10to50.Head = 10)
        Assert.True((number10to50 |> List.last) = 50)

    [<Fact>]
    let ``Using the Cons Operator`` () =
        let shoes = "New Balance" :: "Nike" :: "Puma" :: []

        Assert.True(List.isEmpty shoes |> not)

    [<Fact>]
    let ``Length of a List`` () = 
        let cars = ["Toyota"; "Isuzu"; "Ford"; "Tata Safari"]
        Assert.Equal(4, cars.Length)

    [<Fact>]
    let ``Check if type is a List`` () = 
        let emptyList = []
        Assert.True(emptyList.GetType().GetGenericTypeDefinition() = typedefof<List<_>>)

    [<Fact>]
    let ``Accessing Elements`` () = 
        
        let cars = ["Toyota"; "Mazda"; "Mitsubishi"]
        
        Assert.True(List.nth cars 0 = "Toyota")
        Assert.True(cars.[0] = "Toyota")
        Assert.True(cars.Item(0) = "Toyota")
    
    [<Fact>]
    let ``Head and Tails List`` () = 
        let mobilePhones = ["Samsung"; "IPhone"; "Huwaei"]
        
        let head = mobilePhones.Head
        let tails = mobilePhones.Tail

        let rec contains fn l = 
            if l  = [] then false
            else fn(List.head l) || contains fn (List.tail l)

        Assert.Equal("Samsung", head)
        
        let containsIPhone = (tails |> contains (fun element-> element = "IPhone" ))
        Assert.True(containsIPhone)
        
        let containsHuwaei = (tails |> contains  (fun element-> element = "Huwaei"))
        Assert.True(containsHuwaei)
    
    [<Fact>]
    let ``Simple Way to Concat a List`` () = 
        let twoListOfCars = ["Toyota"; "Isuzu"] @ ["Ford"; "Tata Safari"]

        Assert.True(twoListOfCars.Head = "Toyota")
        Assert.True((twoListOfCars |> List.last) = "Tata Safari")
    
    [<Fact>]
    let ``Concat List`` () = 
        let inputDevice = ["keyboard"; "mouse"; "microphone"]
        
        let outputDevice = ["printer"; "monitor";"speaker"]
        
        let desktop = [inputDevice; ["CPU"; "Motherboard"; "RAM"; "HDD"]; outputDevice] |> List.concat 

        let len:int = (desktop.Length) - 1

        for i = 0 to len do
            let message = $"{i}={desktop.[i]}"  
            outputs.WriteLine(message)
        
        Assert.Equal(10,desktop.Length)

    [<Fact>]
    let ``Append List`` () = 
        let cars1 = ["Toyota"; "Mazda"; "Mitsubishi"]
        let cars2 = ["Ford"]

        let carResult = cars2 |> List.append  cars1

        Assert.True(carResult.Head = "Toyota")
        Assert.True((carResult |> List.last)  = "Ford")

    