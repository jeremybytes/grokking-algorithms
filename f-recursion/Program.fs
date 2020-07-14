// Learn more about F# at http://fsharp.org

open System

let rec factorial input =
    let answer = 
        match input with
            | 1 -> 1 
            | _ -> input * (factorial (input-1))
    printfn "%i %i" input answer
    answer
        

[<EntryPoint>]
let main argv =
    printfn "Factorial of %i is %i" 15 (factorial 15)
    0 // return an integer exit code
