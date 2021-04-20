namespace Fzero

open System.Collections.Generic


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
    1


  // def sample_batch(self, num_unroll_steps: int, td_steps: int):
  //   games = [self.sample_game() for _ in range(self.batch_size)]
  //   game_pos = [(g, self.sample_position(g)) for g in games]
  //   return [(g.make_observation(i), g.history[i:i + num_unroll_steps],
  //            g.make_target(i, num_unroll_steps, td_steps, g.to_play()))
  //           for (g, i) in game_pos]
