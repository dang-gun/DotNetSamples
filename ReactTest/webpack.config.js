const path = require("path");
const HtmlWebpackPlugin = require("html-webpack-plugin");
const { CleanWebpackPlugin } = require("clean-webpack-plugin");
const MiniCssExtractPlugin = require("mini-css-extract-plugin");
const CssMinimizerPlugin = require("css-minimizer-webpack-plugin");

//소스 위치
const RootPath = path.resolve(__dirname);
const SrcPath = path.resolve(RootPath, "src");

//웹서버가 사용하는 폴더 이름
const WwwRoot = "wwwroot";
//웹서버가 사용하는 폴더 위치
const WwwRootPath = path.resolve(__dirname, WwwRoot);
//리액트 템플릿 위치
const React_IndexHtmlPath = path.resolve(SrcPath, "index.html");
//결과물 출력 폴더 이름
let OutputFolder = "dist";
//결과물 출력 폴더 이름 - 이미지 폴더
const OutputFolder_Images = "images";
//결과물 출력 위치
let OutputPath = path.resolve(WwwRootPath, OutputFolder);
//결과물 출력 위치 - 상대 주소
let OutputPath_relative = path.resolve("/", OutputFolder);


module.exports = (env, argv) =>
{
    //릴리즈(프로덕션)인지 여부
    const EnvPrductionIs = argv.mode === "production";
    if (true === EnvPrductionIs)
    {
        //릴리즈 출력 폴더 변경
        OutputFolder = "production";
        OutputPath = path.resolve(WwwRootPath, OutputFolder);
        OutputPath_relative = path.resolve("/", OutputFolder);
    }

    return {
        //서비스 모드
        mode: EnvPrductionIs ? "production" : "development",
        devtool: "eval-cheap-source-map",
        //devtool: "inline-source-map",
        resolve: {
            extensions: [".js", ".jsx"]
        },
        entry: { // 합쳐질 파일 요소들 입력
            app: [path.resolve(SrcPath, "index.js")],
        },
        output: {// 최종적으로 만들어질 js
            //빌드 위치
            path: OutputPath,
            //웹팩 빌드 후 최종적으로 만들어질 파일
            filename: "app.js"
        },
        module: {
            rules: [
                {//소스 파일
                    test: /\.(js|jsx)$/,
                    exclude: /node_module/,
                    use:
                        [
                            { loader: "babel-loader" },
                        ]
                },
                {//스타일 파일
                    test: /\.(sa|sc|c)ss$/i,
                    exclude: /node_module/,
                    use:
                        [
                            {
                                //개발 버전에서는 style-loader 사용
                                loader: MiniCssExtractPlugin.loader,
                                options: { esModule: false }
                            },
                            {
                                loader: 'css-loader',
                                //options: {
                                //    sourceMap: true,
                                //    modules: {//모든 스타일이 고유이름을 같도록 변경
                                //          //겹치지 않는 이름도 변경하므로 보류
                                //        localIdentName: "[local]--[hash:base64:5]"
                                //    }
                                //}
                            },
                            { loader: 'sass-loader' },
                            { loader: 'postcss-loader' },
                        ]
                },
                {//이미지 파일
                    rules: [
                        {
                            test: /\.(png|jpg|gif|svg)$/,
                            loader: "file-loader",
                            options: {
                                outputPath: OutputFolder_Images,
                                name: "[name].[ext]?[hash]",
                            }
                        },
                    ],
                }
            ]
        },
        optimization: {
            minimizer: [
                new CssMinimizerPlugin(),
            ],
        },
        plugins: [
            // 빌드한 결과물(예>번들파일)을 HTML에 삽입해주는 플러그인
            new HtmlWebpackPlugin({ template: React_IndexHtmlPath }),
            // 성공적으로 다시 빌드 한 후 webpack의 output.path에있는 모든 빌드폴더의 내용물 제거
            new CleanWebpackPlugin(),
            // 별도로 css 파일을 만들어서 빌드하는 Plugin
            new MiniCssExtractPlugin({
                filename: "app.css"
            })
        ],
        devServer: {
            //서비스 포트
            port: "9500",
            /** "static" 
             * This property tells Webpack what static file it should serve
            */
            static: [path.resolve("./", WwwRoot)],
            //브라우저 열지 여부
            open: true,
            //핫리로드 사용여부
            hot: true,
            /** "liveReload"
             * disable live reload on the browser. "hot" must be set to false for this to work
            */
            liveReload: true
        },
    };
}