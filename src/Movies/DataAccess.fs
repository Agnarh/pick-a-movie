module Movies.DataAccess

open Fable.Import
open Thoth.Json

open Types

let private STORAGE_KEY = "pick-a-movie"

let private decoder = Decode.Auto.generateDecoder<State>()

let loadState () =
    Browser.localStorage.getItem(STORAGE_KEY)
    |> unbox
    |> Core.Option.bind (Decode.fromString decoder >> function | Ok r -> Some r | _ -> None)

let private prepareForSaving state =
    { state with MovieList = state.MovieList |> List.map (fun movie -> { movie with IsEditing = false })}

let saveState state =
    let json = Encode.Auto.toString(1, prepareForSaving state)
    Browser.localStorage.setItem(STORAGE_KEY, json)