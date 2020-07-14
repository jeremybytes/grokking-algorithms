open System

let rec binarysearch (targetValue, searchList: int list, (low, high)) =
    let mid = (low + high) / 2
    let guess = searchList.Item(mid)

    if low > high then 
        None
    else
        let compare = guess.CompareTo targetValue
        match compare with
        | 0 -> Some (mid, searchList.Item mid)
        | 1 -> binarysearch(targetValue, searchList, (low, mid-1))
        | -1 -> binarysearch(targetValue, searchList, (mid+1, high))
        | _ -> None

    
[<EntryPoint>]
let main argv =
    let targetValue = 
        match argv.Length with
        | 0 ->
            let rnd = Random()
            rnd.Next(1, 101)
        | _ -> argv.[0] |> int

    let searchList = [1..2..100] |> List.map(fun x -> x)

    printfn "%A" searchList

    match binarysearch(targetValue, searchList, (0,49)) with
    | None -> printfn "Value %i was not found" targetValue
    | Some(x,_) -> printfn "Location of %i is %i" targetValue x

    0 // exit code
