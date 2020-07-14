let rec quicksort inputlist =
    match List.length inputlist with
    | 0 | 1 -> inputlist
    | _ ->
        let pivot = inputlist.Item(0)
        let less = List.filter (fun x -> x < pivot) inputlist
        let greater = List.filter (fun x -> x > pivot) inputlist
        quicksort(less) @ [pivot] @ quicksort(greater)

// Exercise 4.1: Recursive sum
let rec sum inputlist =
    match List.length inputlist with
    | 1 -> inputlist.Head
    | _ -> inputlist.Head + sum(inputlist.Tail)

// Exercise 4.2: Recursive count
let rec count inputlist =
    match List.length inputlist with
    | 1 -> 1
    | _ -> 1 + count(inputlist.Tail)

// Exercise 4.3: Recursive max
let rec max inputlist = 
    match List.length inputlist with
    | 1 -> inputlist.Head
    | 2 -> if (inputlist.Item(0) > inputlist.Item(1)) then inputlist.Item(0) else inputlist.Item(1)
    | _ -> 
        let submax = max(inputlist.Tail)
        if (inputlist.Head > submax) then inputlist.Head else submax

[<EntryPoint>]
let main argv =
    let intlist = [ 87; 92; 34; 1; 90; 25; 78 ];
    let sortedintlist = quicksort(intlist)
    printfn "Initial List: %A" intlist
    printfn "Sorted List: %A" sortedintlist

    printfn "Sum: %i" (sum intlist)
    printfn "Count: %i" (count intlist)
    printfn "Max: %i" (max intlist)

    printfn "------------------------------"

    let namelist = ["Kelly"; "Jeremy"; "Mandy"; "Toby"; "Lulu"; "Penny"; "Max"]
    let sortednamelist = quicksort(namelist)
    printfn "Initial List: %A" namelist
    printfn "Sorted List: %A" sortednamelist

    printfn "Count: %i" (count namelist)
    printfn "Max: %s" (max namelist)

    0 // exit code
