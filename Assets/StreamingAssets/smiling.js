var count;
const video = document.getElementById('video')

Promise.all([
  faceapi.nets.tinyFaceDetector.loadFromUri('/models'),
  faceapi.nets.faceLandmark68Net.loadFromUri('/models'),
  faceapi.nets.faceRecognitionNet.loadFromUri('/models'),
  faceapi.nets.faceExpressionNet.loadFromUri('/models')
]).then(startVideo)

function startVideo() {
  navigator.getUserMedia(
    { video: {} },
    stream => video.srcObject = stream,
    err => console.error(err)
  )
}

video.addEventListener('play', () => {
  const canvas = faceapi.createCanvasFromMedia(video)
  var happiness;
  var count=0;
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
      happiness = expressions.happy;
      //console.log(detections);
      if(happiness >= 0.9){
        count=count+1;
        console.log("smile/happiness count : " ,count);
        //console.log(happiness);
      }
      if(happiness >= 0.9){
        console.log("Smiling");
      }else{
        console.log("Not smiling");
      }
    })
    
  }, 100)
   })
   setTimeout(function(){
    message1();
   },1000);

   setTimeout(function(){
    message2();
   },49000);

   function message1() {
    alert("Click OK to start smiling.");
  }
  function message2() {
    alert("Go back to the maze game.");
  }

