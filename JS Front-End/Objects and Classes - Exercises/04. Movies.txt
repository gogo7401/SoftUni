function Solve(arrInput) {
  let movieCatalog = [];
  
 for (const item of arrInput) {
   let movieName = item.split("addMovie ")[1];
   if (movieName){
    let movie = {};
    movie.name = movieName;
    movieCatalog.push(movie);
   }
   let movieDirector = item.split("directedBy ")[1];
   if (movieDirector){
    let movieName = item.split("directedBy ")[0].trimEnd();
    let result = movieCatalog.find(({ name }) => name === movieName);
    if (result){
      result.director = movieDirector;

    }
   }
   let movieDate = item.split("onDate ")[1];
   if (movieDate){
    let movieName = item.split("onDate ")[0].trimEnd();
    let result = movieCatalog.find(({ name }) => name === movieName);
    if (result){
      result.date = movieDate;
    
    }
   }
 }
 let returnIdex = movieCatalog.findIndex((x) => x.date === undefined || x.director === undefined);
 while (returnIdex != -1){
  movieCatalog.splice(returnIdex, 1);
  returnIdex = movieCatalog.findIndex((x) => x.date === undefined || x.director === undefined);
 }

 for (const item of movieCatalog) {
  const jsn = JSON.stringify(item);
  console.log(jsn);
 }
 


}

Solve([
  "addMovie Fast and Furious",
  "addMovie Godfather",
  "Inception directedBy Christopher Nolan",
  "Godfather directedBy Francis Ford Coppola",
  "Godfather onDate 29.07.2018",
  "Fast and Furious onDate 30.07.2018",
  "Batman onDate 01.08.2018",
  "Fast and Furious directedBy Rob Cohen",
]);
Solve([
  "addMovie The Avengers",
  "addMovie Superman",
  "The Avengers directedBy Anthony Russo",
  "The Avengers onDate 30.07.2010",
  "Captain America onDate 30.07.2010",
  "Captain America directedBy Joe Russo",
]);
