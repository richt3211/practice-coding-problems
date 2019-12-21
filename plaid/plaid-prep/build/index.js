"use strict";
var Node = /** @class */ (function () {
    function Node(val) {
        this.left = null;
        this.right = null;
        this.val = val;
    }
    return Node;
}());
var isValidBst = function (root) {
    // need to check recursively whether or not the tree to left and right are valid bst
    if (root === null) {
        return true;
    }
    var leftValid = isValidBstR(root.left, root.val, root.val, "left", "left");
    var rightValid = isValidBstR(root.right, root.val, root.val, "right", "right");
    return leftValid && rightValid;
};
var isValidBstR = function (root, currentVal, rootVal, dir, half) {
    if (root === null) {
        return true;
    }
    if (dir === "left") {
        if (root.val >= currentVal) {
            return false;
        }
    }
    else if (dir === "right") {
        if (root.val <= currentVal) {
            return false;
        }
    }
    if (half === "right") {
        if (root.val <= rootVal)
            return false;
    }
    else if (half === "left") {
        if (root.val >= rootVal) {
            return false;
        }
    }
    var leftValid = isValidBstR(root.left, root.val, rootVal, "left", half);
    var rightValid = isValidBstR(root.right, root.val, rootVal, "right", half);
    return leftValid && rightValid;
};
var test1 = function () {
    var root = new Node(2);
    root.left = new Node(1);
    root.right = new Node(3);
    console.log(isValidBst(root));
};
var test2 = function () {
    var root = new Node(10);
    root.left = new Node(5);
    root.left.left = null;
    root.left.right = null;
    root.right = new Node(15);
    root.right.left = new Node(6);
    root.right.right = new Node(20);
    console.log(isValidBst(root));
};
test1();
test2();
//# sourceMappingURL=index.js.map