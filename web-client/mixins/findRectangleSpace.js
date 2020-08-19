var screenWidth = 0;
var screenHeight = 0;
var boxes = [];

function doesBoxCollide(container, box) {
    // console.dir(container.x > box.x + box.w);
    // console.dir(container.x + container.w < box.x );
    // console.dir(container.y > box.y + box.h);
    // console.dir(container.y + container.h < box.y);

    return (
        container.x > box.x + box.w ||
        container.x + container.w < box.x ||
        container.y > box.y + box.h ||
        container.y + container.h < box.y
    );
}

export default {
    methods: {
        start(screenSize, currentContainers) {
            boxes = [];
            if (currentContainers.length === 0) {
                return [0, 0];
            }

            screenWidth = screenSize.width;
            screenHeight = screenSize.height;

            for (var i = 0; i < currentContainers.length; i++) {
                var currBox = currentContainers[i];
                boxes.push({
                    x: currBox.x,
                    y: currBox.y,
                    w: currBox.w,
                    h: currBox.h
                });
            }
            console.dir(boxes);

            var newBox = {
                x: 0,
                y: 0,
                w: 300,
                h: 200
            };

            var hasCollision = false;
            var repeat = true;
            var count = 0;

            while (repeat) {
                count++;
                repeat = true;
                for (var i = 0; i < boxes.length; i++) {
                    var container = boxes[i];
                    console.dir(container);
                    if (doesBoxCollide(container, newBox)) {
                        console.dir("Collision");
                        hasCollision = true;
                        break;
                    }
                }

                if (!hasCollision) {
                    console.dir("Fits here!!");
                    console.dir(newBox);
                    repeat = false;
                } else {
                    //if collision check from a new location
                    newBox.x = container.x + container.w;
                    if (newBox.x + newBox.w > screenWidth) {
                        newBox.x = 0;
                        newBox.y = container.y + container.h;
                        if (newBox.y + newBox.h > screenHeight) {
                            console.dir("Outa bounds");
                            repeat = false;
                        }
                    }
                    hasCollision = false;
                }
            }
            console.dir(newBox);

            return [newBox.x, newBox.y];
        }
    }
};
