let rec quicksort (inputlist) =
    match List.length inputlist with
    | 0 | 1 -> inputlist
    | _ ->
        let pivot = inputlist.Item(0)
        let less = List.filter (fun x -> x < pivot) inputlist
        let greater = List.filter (fun x -> x > pivot) inputlist
        quicksort(less) @ [pivot] @ quicksort(greater)

[<EntryPoint>]
let main argv =
    let intlist = [ 87; 92; 34; 1; 90; 25; 78 ];
    let sortedintlist = quicksort(intlist)
    printfn "Initial List: %A" intlist
    printfn "Sorted List: %A" sortedintlist

    printfn "------------------------------"

    let namelist = ["Kelly"; "Jeremy"; "Mandy"; "Toby"; "Lulu"; "Penny"; "Max"]
    let sortednamelist = quicksort(namelist)
    printfn "Initial List: %A" namelist
    printfn "Sorted List: %A" sortednamelist

    0 // exit code
