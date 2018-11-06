module Movies.Views.InputMovieView

open Fable.Helpers.React
open Fable.Helpers.React.Props
open Fable.Core.JsInterop

open Movies.Types

let inputMovieView state dispatch =
    div [ ClassName "input-movie-wrapper" ] [
        div [ ClassName "input-group" ] [
            input [
                ClassName "form-control"
                Type "text"
                Value state.Field
                OnKeyDown (fun ev ->
                    match ev.keyCode with
                    | 13. -> dispatch AddMovie
                    | _ -> ())
                OnChange (fun ev -> !!ev.target?value |> ChangeField |> dispatch)
            ]
            div [ ClassName "input-group-append" ] [
                button [
                    Disabled state.IsMovieExists
                    ClassName "btn btn-outline-secondary"
                    OnClick (fun _ -> AddMovie |> dispatch)
                ] [
                    str "Add Movie Name"
                ]
            ]
        ]
    ]