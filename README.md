# Subtitle Files Renamer
Batch rename subtitle files to match the name of their media file.  
So that your media player (like potplayer) can autoload the subtitle file when you open your media file.  

## Explication
Media files and subtitle files are normally composed by:  
prefix + episode + to_delete + to_add + suffix + extension

### For example:  
We have 4 files:  
myfilm.s01e01.first.episode.spark.mp4  
myfilm.s01e02.sec.episode.spark.mp4  
myfilmqq.01.1st.sparkss.ass  
myfilmqq.02.2nd.sparkss.ass  

In this case:  

type | prefix | episode | to delete | to add | suffix | extension
----- | ------ | ----------- | ------------- | ---------- | ------ | ---------
media | myfilm.s01e | 01 - 02 |  | .first.episode, etc | .spark | .mp4
sub | myfilmqq. | 01 - 02 | .1st, etc | |  .sparkss | .ass
  
Fill these info into the program, click check and rename.  
![with params](https://raw.githubusercontent.com/nathankun/subtitle-renamer/master/img/2.png)
  
Or just fill nothing and click check directly, this might works too.
![without params](https://raw.githubusercontent.com/nathankun/subtitle-renamer/master/img/1.png)
