module Movies.View

open Fable.Helpers.React
open Fable.Helpers.React.Props

open Movies.Views.InputMovieView
open Movies.Views.MovieListView
open Movies.Views.PickMovieView

let root state dispatch =
    div [ ClassName "container" ] [
        div [ ClassName "row justify-content-center" ] [
            div [ ClassName "col-xs-4" ] [
                inputMovieView state dispatch
                movieListView state.MovieList dispatch
                pickMovieView state dispatch
            ]
        ]
    ]