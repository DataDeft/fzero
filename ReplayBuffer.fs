namespace Fzero

open System.Collections.Generic
open System


type ReplayBuffer = {
  WindowsSize: uint32
  BatchSize: uint32
  Buffer: Queue<int>
} with

  member this.SaveGame (game) =
    match uint32(this.Buffer.Count) with
    | l when l = this.WindowsSize || l > this.WindowsSize ->
        this.Buffer.Dequeue() |> ignore
        this.Buffer.Enqueue(game)
    | _ -> this.Buffer.Enqueue(game)

  member this.SampleBatch (numUnrollSteps:int) (numTdSteps:int) =

    let r = Random()

    let games =

      this.Buffer.ToArray()
      |> Seq.sortBy (fun _ -> r.Next())
      |> Seq.take (int(this.BatchSize))

    let gamesPos = games
    // TODO: I do not understand what this function does or what it needs to return
    gamesPos
