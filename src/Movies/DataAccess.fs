module Movies.DataAccess

// open Fable.Import
// open Thoth.Json

// open Types

// let private STORAGE_KEY = "pick-a-movie"

// let private decoder = Decode.Auto.generateDecoder<State>()

// let loadState () =
//     Browser.localStorage.getItem(STORAGE_KEY)
//     |> unbox
//     |> Core.Option.bind (Decode.fromString decoder >> function | Ok r -> Some r | _ -> None)

// let saveState (model: State) =
//     let json = Encode.Auto.toString(1, model)
//     Browser.localStorage.setItem(STORAGE_KEY, json)