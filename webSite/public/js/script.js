var scene = document.getElementById('scene');
var parallax = new Parallax(scene, {
    selector: '.layer'
  });

var scene2 = document.getElementById('scene2');
var parallax = new Parallax(scene2, {
    selector: '.layer'
  });

var scene3 = document.getElementById('scene3');
var parallax = new Parallax(scene3, {
    selector: '.layer'
  });


  /* //Unity
  var buildUrl = "Build";
      var loaderUrl = buildUrl + "/Builds_Webgl.loader.js";
      var config = {
        dataUrl: buildUrl + "/Builds_Webgl.data.gz",
        frameworkUrl: buildUrl + "/Builds_Webgl.framework.js.gz",
        codeUrl: buildUrl + "/Builds_Webgl.wasm.gz",
        streamingAssetsUrl: "StreamingAssets",
        companyName: "DefaultCompany",
        productName: "Daily_Relaxation",
        productVersion: "0.1",
      };

      var container = document.querySelector("#unity-container");
      var canvas = document.querySelector("#unity-canvas");
      var loadingBar = document.querySelector("#unity-loading-bar");
      var progressBarFull = document.querySelector("#unity-progress-bar-full");
      var fullscreenButton = document.querySelector("#unity-fullscreen-button");
      var mobileWarning = document.querySelector("#unity-mobile-warning");

      // By default Unity keeps WebGL canvas render target size matched with
      // the DOM size of the canvas element (scaled by window.devicePixelRatio)
      // Set this to false if you want to decouple this synchronization from
      // happening inside the engine, and you would instead like to size up
      // the canvas DOM size and WebGL render target sizes yourself.
      // config.matchWebGLToCanvasSize = false;

      if (/iPhone|iPad|iPod|Android/i.test(navigator.userAgent)) {
        container.className = "unity-mobile";
        // Avoid draining fillrate performance on mobile devices,
        // and default/override low DPI mode on mobile browsers.
        config.devicePixelRatio = 1;
        mobileWarning.style.display = "block";
        setTimeout(() => {
          mobileWarning.style.display = "none";
        }, 5000);
      } else {
        canvas.style.width = "960px";
        canvas.style.height = "600px";
      }
      loadingBar.style.display = "block";

      var script = document.createElement("script");
      script.src = loaderUrl;
      script.onload = () => {
        createUnityInstance(canvas, config, (progress) => {
          progressBarFull.style.width = 100 * progress + "%";
        }).then((unityInstance) => {
          loadingBar.style.display = "none";
          fullscreenButton.onclick = () => {
            unityInstance.SetFullscreen(1);
          };
        }).catch((message) => {
          alert(message);
        });
      };
      document.body.appendChild(script); */