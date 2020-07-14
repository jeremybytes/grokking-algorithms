// Learn more about F# at http://fsharp.org

open System

let rec selectionsort inputlist =
    match List.length inputlist with
    | 1 -> inputlist
    | _ ->
        let smallest = List.min inputlist
        [smallest] @ selectionsort (List.except [smallest] inputlist)

[<EntryPoint>]
let main argv =
    let intlist = [ 87; 92; 34; 1; 90; 25; 78 ];
    let sortedintlist = selectionsort(intlist)
    printfn "Initial List: %A" intlist
    printfn "Sorted List: %A" sortedintlist

    printfn "------------------------------"

    let namelist = ["Kelly"; "Jeremy"; "Mandy"; "Toby"; "Lulu"; "Penny"; "Max"]
    let sortednamelist = selectionsort(namelist)
    printfn "Initial List: %A" namelist
    printfn "Sorted List: %A" sortednamelist

    0 // return an integer exit code
