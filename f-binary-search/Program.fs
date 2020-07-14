// Learn more about F# at http://fsharp.org

open System
open System.Linq

let rec findValue (targetValue, searchList: int list, (low, high)) =
    let mid = (low + high) / 2
    let guess = searchList.Item(mid)

    if low > high then 
        None
    else
        let compare = guess.CompareTo targetValue
        match compare with
        | 0 -> Some (mid, searchList.Item mid)
        | 1 -> findValue(targetValue, searchList, (low, mid-1))
        | -1 -> findValue(targetValue, searchList, (mid+1, high))
        | _ -> None

    
[<EntryPoint>]
let main argv =
    let rnd = Random()
    let targetValue = rnd.Next(-1, 101)

    let searchList = [2..2..100] |> List.map(fun x -> x)

    printfn "%A" searchList

    match findValue(targetValue, searchList, (0,49)) with
    | None -> printfn "Value %i was not found" targetValue
    | Some(x,_) -> printfn "Location of %i is %i" targetValue x

    0
