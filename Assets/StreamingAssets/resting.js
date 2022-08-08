var count=0;
var t;

const video = document.getElementById('video')

Promise.all([
  faceapi.nets.tinyFaceDetector.loadFromUri('/models'),
  faceapi.nets.faceLandmark68Net.loadFromUri('/models'),
  faceapi.nets.faceRecognitionNet.loadFromUri('/models'),
  faceapi.nets.faceExpressionNet.loadFromUri('/models')
]).then(startVideo)

function start(){
  t = setInterval(countEmotion, 100);

  setTimeout(() => {
    clearInterval(t);
  }, 10000);
}


/*
var timecount = 10;
var cancel = setInterval(function (){
  if(timecount === 0){
    clearInterval(cancel);
    console.log("Done");
   
  } 
  clearTimeout(t);
  timecount -= 1;
}, 1000);

*/






function startVideo() {
  navigator.getUserMedia(
    { video: {} },
    stream => video.srcObject = stream,
    err => console.error(err)
  )
}
function countEmotion(){
  console.log("detection count : " ,count);
  
}



video.addEventListener('play', () => {
  const canvas = faceapi.createCanvasFromMedia(video)
  var happiness;
  
  document.body.append(canvas)
  const displaySize = { width: video.width, height: video.height }
  faceapi.matchDimensions(canvas, displaySize)
  setInterval(async () => {
    const detections = await faceapi.detectAllFaces(video, new faceapi.TinyFaceDetectorOptions()).withFaceLandmarks().withFaceExpressions()
    const resizedDetections = faceapi.resizeResults(detections, displaySize)
    canvas.getContext('2d').clearRect(0, 0, canvas.width, canvas.height)
    faceapi.draw.drawDetections(canvas, resizedDetections)
    faceapi.draw.drawFaceLandmarks(canvas, resizedDetections)
    faceapi.draw.drawFaceExpressions(canvas, resizedDetections)
    resizedDetections.forEach(result => {
      const {expressions} = result
      happiness = expressions.neutral;
      if(happiness >=0.1){
        count=count+1;
        countEmotion();
        
      }else{
        console.log("Cannot detect face")
      }
      
    })
    
    setTimeout(stop, 10000);
    
  }, 100)
   });





